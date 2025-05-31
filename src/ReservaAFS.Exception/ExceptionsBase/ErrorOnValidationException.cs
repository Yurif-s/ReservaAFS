namespace ReservaAFS.Exception.ExceptionsBase;
public class ErrorOnValidationException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
