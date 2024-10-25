using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class CancelPreparedUnitsModel
{
    public bool HasCanceled { get; set; }
    public GeneralErrorModel Error { get; set; }
    
    public static CancelPreparedUnitsModel Map(Response<bool> entity)
    {
        return new CancelPreparedUnitsModel
        {
            HasCanceled = entity.Data,
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
        return $"HasCanceledPreparedUnits: {HasCanceled}" + Error;
    }
}