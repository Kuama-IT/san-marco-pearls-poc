using System.Collections.Generic;
using pearls.Responses.Entities;

namespace pearls.Responses.Models;

public class CorrectFillLevelModel
{
    public IEnumerable<object> HasCorrected { get; set; }

    public GeneralErrorModel Error { get; set; }
    
    public static CorrectFillLevelModel Map(Response<object[]> entity)
    {
        return new CorrectFillLevelModel
        {
            HasCorrected = entity.Data,
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
        return $"HasCorrected: {string.Join(" - ", HasCorrected)}\n" + Error;
    }
}