using pearls.PearlsResponses;

namespace pearls.Responses.Models;

public struct LicenseCodeModel
{
    public string LicenseCode;
    public GeneralErrorModel? Error;
    
    public static LicenseCodeModel Map(PearlResponse<string> entity)
    {
        return new LicenseCodeModel
        {
            LicenseCode = entity.Data,
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
        return $"LicenseCode: {LicenseCode}" + Error;
    }
}