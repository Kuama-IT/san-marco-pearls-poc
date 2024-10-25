using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public struct PollModel
{
    public bool IsConnected;

    public GeneralErrorModel? Error;

    public static PollModel Map(Response<bool?> entity)
    {
        return new PollModel
        {
            IsConnected = entity.Data == true,
            Error = new GeneralErrorModel
            {
                Error = entity.Error,
                ErrorDescription = entity.ErrorDescription,
                ErrorType = entity.ErrorType,
                StackTrace = entity.StackTrace
            }
        };
    }

    public override string ToString()
    {
        return $"IsConnected: {IsConnected}" + Error;
    }
}