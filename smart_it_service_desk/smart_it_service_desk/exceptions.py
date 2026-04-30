class TicketError(Exception):
    pass

class InvalidTicketID(TicketError):
    pass

class DuplicateTicket(TicketError):
    pass

class EmptyFieldError(TicketError):
    pass