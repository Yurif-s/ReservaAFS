using System.Net;

namespace ReservaAFS.Exception.ExceptionsBase;
public class NotFoundException : ReservaAFSException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
