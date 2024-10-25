#nullable enable
using System;
using CookComputing.XmlRpc;

namespace pearls.Responses.Entities
{
    public struct ProtectionStatusResponse
    {
        [XmlRpcMember("status")] public int Status;

        [XmlRpcMember("computerid")] public string ComputerId;

        [XmlRpcMember("online")] public bool IsOnline;

        [XmlRpcMember("errmsg")] [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string ErrorDescription;

        [XmlRpcMember("errno"), XmlRpcMissingMapping(MappingAction.Ignore)]
        public int? ErrorNumber;

        [XmlRpcMember("features")] public string[] AvailableFeatures;

        [XmlRpcMember("expdate")] public int[]? ExpirationDate;

        [XmlRpcMember("daysleft")] public Int32? DaysLeft;

        public string ToString()
        {
            return $"HasValidLicense: {Status > 0}\n" +
                   $"ComputerId: {ComputerId}\n" +
                   $"IsOnline: {IsOnline}\n" +
                   $"AvailableFeatures: {string.Join(",", AvailableFeatures)}\n" +
                   $"ExpirationDate: {ExpirationDate}\n" +
                   $"DaysLeft: {DaysLeft}\n" +
                   $"Error Number: {ErrorNumber}\n" +
                   $"Error Description: {ErrorDescription}\n";
        }

        // [XmlRpcMember("license_code")] public string LicenseCode;
        //
        // [XmlRpcMember("activation_request")] public string ActivationRequest;
        //
        // [XmlRpcMember("activation_license_code")]
        // public string ActivationLicenseCode;
        //
        // [XmlRpcMember("deactivation_request")] public string DeactivationRequest;
        //
        // [XmlRpcMember("deactivation_license_code")]
        // public string DeactivationLicenseCode;
    }
}