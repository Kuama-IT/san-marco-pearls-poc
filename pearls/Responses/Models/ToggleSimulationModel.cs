using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class ToggleSimulationModel
{
    public bool IsInSimulationMode { get; set; }
    public GeneralErrorModel Error { get; set; }

    public static ToggleSimulationModel Map(Response<bool> response)
    {
        return new ToggleSimulationModel
        {
            IsInSimulationMode = response.Data,
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
        return $"IsInSimulationMode: {IsInSimulationMode}\n" + Error;
    }
}