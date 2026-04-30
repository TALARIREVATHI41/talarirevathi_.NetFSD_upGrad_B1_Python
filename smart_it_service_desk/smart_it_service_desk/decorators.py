from logger import log_info

def log_decorator(func):
    def wrapper(*args, **kwargs):
        log_info(f"Calling {func.__name__}")
        return func(*args, **kwargs)
    return wrapper