from collections import Counter
from datetime import datetime, timedelta

class ReportGenerator:
    def __init__(self, tickets):
        self.tickets = tickets

    def daily(self):
        total = len(self.tickets)
        open_t = sum(1 for t in self.tickets if t["status"]=="Open")
        closed = sum(1 for t in self.tickets if t["status"]=="Closed")
        high = sum(1 for t in self.tickets if t["priority"]=="P1")

        print("\n--- DAILY REPORT ---")
        print("Total:", total)
        print("Open:", open_t)
        print("Closed:", closed)
        print("High Priority:", high)

    def monthly(self):
        issues = [t["issue"] for t in self.tickets]
        depts = [t["department"] for t in self.tickets]

        print("\n--- MONTHLY REPORT ---")
        print("Most Common Issue:", Counter(issues).most_common(1))
        print("Top Department:", Counter(depts).most_common(1))