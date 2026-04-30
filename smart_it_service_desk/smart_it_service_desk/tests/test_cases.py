import unittest
from tickets import Ticket


class TestDesk(unittest.TestCase):

    def test_ticket_creation(self):
        t=Ticket(
            "Revathi",
            "IT",
            "Server Down"
        )
        self.assertEqual(t.priority,"P1")


    def test_priority_logic(self):
        self.assertEqual(
            Ticket.get_priority(
                "Password Reset"
            ),
            "P4"
        )


    def test_sla(self):
        t=Ticket(
            "A",
            "IT",
            "Server Down"
        )
        self.assertIsNotNone(
            t.sla_deadline()
        )


if __name__=="__main__":
    unittest.main()