using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class DispenseUnitsModel
{
    public bool HasDispensed { get; set; }
    public GeneralErrorModel Error { get; set; }

    public static DispenseUnitsModel Map(Response<bool> response)
    {
        return new DispenseUnitsModel
        {
            HasDispensed = response.Data,
            Error = new GeneralErrorModel
            {
                Error = response.Error,
                ErrorDescription = response.ErrorDescription,
                ErrorType = response.ErrorType,
                StackTrace = response.StackTrace
            }
        };
    }

    public override string ToString()
    {
        return $"HasDispensed: {HasDispensed}\n" + Error;
    }
}