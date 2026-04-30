import json, csv

TICKET_FILE = "data/tickets.json"

def load_tickets():
    try:
        with open(TICKET_FILE, "r") as f:
            return json.load(f)
    except:
        return []

def save_tickets(tickets):
    with open(TICKET_FILE, "w") as f:
        json.dump(tickets, f, indent=4)

def backup_csv(tickets):
    with open("data/backup.csv", "w", newline="") as f:
        writer = csv.writer(f)
        writer.writerow(["id","employee","department","issue","priority","status"])
        for t in tickets:
            writer.writerow([t[k] for k in ["id","employee","department","issue","priority","status"]])