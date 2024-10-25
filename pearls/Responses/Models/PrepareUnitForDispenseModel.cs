using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class PrepareUnitForDispenseModel
{
    public string[] Units { get; set; }
    public GeneralErrorModel Error { get; set; }

    public static PrepareUnitForDispenseModel Map(Response<string[]> response)
    {
        return new PrepareUnitForDispenseModel
        {
            Units = response.Data,
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
        return $"Units: {string.Join(" - ", Units)}\n" + Error;
    }
}