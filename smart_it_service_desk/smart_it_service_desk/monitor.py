import psutil
from tickets import TicketManager
from logger import log_critical

class Monitor:
    def __init__(self):
        self.tm = TicketManager()

    def check(self):
        cpu = psutil.cpu_percent()
        ram = psutil.virtual_memory().percent
        disk = psutil.disk_usage('/').free / psutil.disk_usage('/').total * 100
        net = psutil.net_io_counters().bytes_sent

        print("CPU:", cpu, "%")
        print("RAM:", ram, "%")
        print("Disk Free:", round(disk, 2), "%")
        print("Network Usage:", net)

        if cpu > 90:
            self.tm.create_ticket("System","Infra","Server Down")
            log_critical("CPU High")

        if ram > 95:
            self.tm.create_ticket("System","Infra","Server Down")
            log_critical("RAM High")

        # ✅ FIXED CONDITION
        if disk < 10:
            self.tm.create_ticket("System","Infra","Disk Full")
            log_critical("Disk Full")