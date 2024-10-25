namespace pearls.Responses.Models;

public struct GeneralErrorModel
{
    public string Error;
    public string ErrorDescription;
    public string ErrorType;
    public string StackTrace;

    public override string ToString()
    {
        return $"\nError: {Error}" +
               $"\nErrorDescription: {ErrorDescription}" +
               $"\nErrorType: {ErrorType}" +
               $"\nStackTrace:\n{StackTrace}";
    }
}