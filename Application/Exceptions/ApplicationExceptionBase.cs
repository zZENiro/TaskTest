namespace Application.Exceptions;

public abstract class ApplicationExceptionBase : Exception
{
    protected ApplicationExceptionBase(string template, params object[] properties)
        : base(string.Format(template, properties))
    {
        
    }
}