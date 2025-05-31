namespace ReservaAFS.Communication.Responses;
public class ResponseErrorMessageJson
{
    public List<string> ErrorMessages { get; set; }
    public ResponseErrorMessageJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }
    public ResponseErrorMessageJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
