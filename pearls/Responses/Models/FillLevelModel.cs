using System.Collections.Generic;
using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class FillLevelModel
{
    public IEnumerable<double> FillLevels { get; set; }
    public GeneralErrorModel Error { get; set; }

    public static FillLevelModel Map(Response<double[]> response)
    {
        return new FillLevelModel
        {
            FillLevels = response.Data,
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
        return $"FillLevels: {string.Join(" - ", FillLevels)}\n" + Error;
    }
}