from tickets import TicketManager
from monitor import Monitor
from reports import ReportGenerator
from itil import ProblemManagement
from utils import backup_csv

def menu():
    tm = TicketManager()
    mon = Monitor()

    while True:
        print("""
1 Create Ticket
2 View Tickets
3 Search Ticket
4 Update Status
5 Close Ticket
6 Delete Ticket
7 SLA Check
8 Monitor Alerts
9 Reports
10 Backup CSV
11 Exit
""")

        ch = input("Choice:")

        try:
            if ch == "1":
                tm.create_ticket(input("Name:"), input("Department:"), input("Issue:"))

            elif ch == "2":
                tm.view_tickets()

            elif ch == "3":
                print(tm.search_ticket(int(input("ID:"))))

            elif ch == "4":
                tm.update_status(int(input("ID:")), input("Status:"))

            elif ch == "5":
                tm.close_ticket(int(input("ID:")))

            elif ch == "6":
                tm.delete_ticket(int(input("ID:")))

            elif ch == "7":
                tm.sla_check()

            elif ch == "8":
                mon.check()

            elif ch == "9":
                rg = ReportGenerator(tm.tickets)
                rg.daily()
                rg.monthly()

                pm = ProblemManagement()
                print("Problem Records:", pm.repeated_issue_analysis(tm.tickets))

            elif ch == "10":
                backup_csv(tm.tickets)
                print("✅ Backup completed successfully (backup.csv created)")

            elif ch == "11":
                break

        except Exception as e:
            print("Error:", e)

if __name__ == "__main__":
    menu()