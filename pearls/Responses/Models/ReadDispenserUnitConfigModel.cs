using pearls.PearlsResponses;

namespace pearls.Responses.Models;

public class ReadDispenserUnitConfigModel
{
    public string ColorName { get; set; }

    public GeneralErrorModel Error { get; set; }
    
    public static ReadDispenserUnitConfigModel Map(PearlResponse<string> entity)
    {
        return new ReadDispenserUnitConfigModel
        {
            ColorName = entity.Data,
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
        return $"ColorName: {ColorName}\n" + Error;
    }
}