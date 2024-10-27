namespace Application.Exceptions;

public class BadRequestException(string message, params object[] properties)
    : ApplicationExceptionBase(message, properties);