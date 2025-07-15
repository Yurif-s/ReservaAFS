namespace ReservaAFS.Exception.ExceptionsBase;
public class NotFoundException : ReservaAFSException
{
    public string Error { get; set; }
    public NotFoundException(string errorMessage)
    {
        Error = errorMessage;
    }
}
