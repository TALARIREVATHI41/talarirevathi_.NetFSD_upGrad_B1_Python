from datetime import datetime, timedelta
from utils import load_tickets, save_tickets
from exceptions import *
from logger import *
from decorators import log_decorator
import re


class Ticket:
    sla_rules = {"P1":1,"P2":4,"P3":8,"P4":24}

    priority_rules = {
        "Server Down":"P1",
        "Internet Down":"P2",
        "Laptop Slow":"P3",
        "Password Reset":"P4"
    }

    counter = 1001

    def __init__(self, name, dept, issue):

        # ✅ Regex validation
        if not re.match("^[A-Za-z ]+$", name):
            raise ValueError("Invalid Name")

        if not name or not issue:
            raise EmptyFieldError("Fields cannot be empty")

        self.id = Ticket.counter
        Ticket.counter += 1

        self.employee = name
        self.department = dept
        self.issue = issue
        self.priority = self.get_priority(issue)
        self.status = "Open"
        self.created = str(datetime.now())

    @staticmethod
    def get_priority(issue):
        return Ticket.priority_rules.get(issue, "P4")

    def to_dict(self):
        return self.__dict__


class TicketManager:

    def __init__(self):
        self.tickets = load_tickets()

        if self.tickets:
            Ticket.counter = max(t["id"] for t in self.tickets) + 1

    @log_decorator
    def create_ticket(self, name, dept, issue):
        ticket = Ticket(name, dept, issue)

        self.tickets.append(ticket.to_dict())
        save_tickets(self.tickets)

        log_info(f"Ticket Created {ticket.id}")
        print(f"✅ Ticket Created | ID: {ticket.id} | Priority: {ticket.priority}")

    def view_tickets(self):
        for t in sorted(self.tickets, key=lambda x: x["priority"]):
            print(t)

    def search_ticket(self, id):
        for t in self.tickets:
            if t["id"] == id:
                return t
        raise InvalidTicketID("Ticket Not Found")

    def update_status(self, id, status):
        for t in self.tickets:
            if t["id"] == id:
                t["status"] = status
                save_tickets(self.tickets)
                log_info(f"Updated {id}")
                return
        raise InvalidTicketID("Invalid ID")

    def close_ticket(self, id):
        self.update_status(id, "Closed")

    def delete_ticket(self, id):
        self.tickets = [t for t in self.tickets if t["id"] != id]
        save_tickets(self.tickets)

    def sla_check(self):
        now = datetime.now()
        seen = set()

        for t in self.tickets:
            if t["status"] != "Closed" and t["id"] not in seen:

                created = datetime.fromisoformat(t["created"])
                due = created + timedelta(hours=Ticket.sla_rules[t["priority"]])

                if now > due:
                    print("SLA BREACHED:", t["id"])
                    log_warning(f"SLA breach {t['id']}")
                    seen.add(t["id"])

                elif now > due - timedelta(minutes=30):
                    print("⚠️ SLA Warning:", t["id"])