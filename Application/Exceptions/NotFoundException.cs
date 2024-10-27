namespace Application.Exceptions;

public class NotFoundException(string message, params object[] properties)
    : ApplicationExceptionBase(message, properties);