namespace ReservaAFS.Exception.ExceptionsBase;
public class ErrorOnValidationException : ReservaAFSException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
