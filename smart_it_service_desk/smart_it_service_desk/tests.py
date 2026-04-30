import unittest
from tickets import Ticket, TicketManager

class TestDesk(unittest.TestCase):

    def test_ticket_creation(self):
        t = Ticket("Revathi","IT","Server Down")
        self.assertEqual(t.priority,"P1")

    def test_priority_logic(self):
        self.assertEqual(Ticket.get_priority("Password Reset"),"P4")

    def test_sla(self):
        t = Ticket("A","IT","Server Down")
        self.assertIsNotNone(t.created)

    def test_manager(self):
        tm = TicketManager()
        tm.create_ticket("Test","IT","Laptop Slow")
        self.assertTrue(len(tm.tickets) > 0)

if __name__ == "__main__":
    unittest.main()