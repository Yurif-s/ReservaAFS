namespace ReservaAFS.Exception.ExceptionsBase;
public abstract class ReservaAFSException : SystemException
{
    protected ReservaAFSException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
