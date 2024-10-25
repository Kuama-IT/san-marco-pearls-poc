#nullable enable
using System;
using pearls.PearlsResponses;
using pearls.Responses.Entities;

namespace pearls.Responses.Models
{
    public struct ProtectionStatusModel
    {
        public bool HasValidLicense;

        public string ComputerId;

        public bool IsOnline;

        public string[] AvailableFeatures;

        public DateTime ExpirationDate;

        public int? DaysLeft;

        public GeneralErrorModel? Error;

        public static ProtectionStatusModel Map(PearlResponse<ProtectionStatusResponse> entity)
        {
            var response = entity.Data;
            return new ProtectionStatusModel
            {
                HasValidLicense = response.Status > 0,
                ComputerId = response.ComputerId,
                IsOnline = response.IsOnline,
                AvailableFeatures = response.AvailableFeatures,
                ExpirationDate = response.ExpirationDate == null ? DateTime.Now : new DateTime(year: response.ExpirationDate[0], month: response.ExpirationDate[1],
                    day: response.ExpirationDate[2]),
                DaysLeft = response.DaysLeft,
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
            return $"HasValidLicense: {HasValidLicense}\n" +
                   $"ComputerId: {ComputerId}\n" +
                   $"IsOnline: {IsOnline}\n" +
                   $"AvailableFeatures: {string.Join(",", AvailableFeatures)}\n" +
                   $"ExpirationDate: {ExpirationDate}\n" +
                   $"DaysLeft: {DaysLeft}\n" +
                   Error;
        }
    }
}