using CookComputing.XmlRpc;
using pearls.PearlsResponses;
using pearls.Responses.Entities;

namespace pearls.ProxyClient
{
    [XmlRpcUrl("http://127.0.0.1:9111")]
    public interface IPearlXmlRpcClient : IXmlRpcProxy
    {
        [XmlRpcMethod(method: "connect")]
        void Connect(string port, string address, int baudRate, string dispFamily);

        [XmlRpcMethod(method: "connect")]
        void Connect(string port, string address, int baudRate);

        [XmlRpcMethod(method: "activate_online")]
        Response<int?> Activate(string license);

        [XmlRpcMethod(method: "poll")]
        Response<bool?> Poll();

        [XmlRpcMethod(method: "protection_status")]
        Response<ProtectionStatusResponse> ProtectionStatus();

        [XmlRpcMethod(method: "license_code")]
        Response<string> GetLicenseCode();

        [XmlRpcMethod(method: "readDispenserUnitConfig")]
        Response<string> ReadDispenserUnitConfig(int circuitNumber);

        [XmlRpcMethod(method: "getFillLevel")]
        Response<double[]> GetFillLevel(string colorantName);

        [XmlRpcMethod(method: "prepareUnitForDispense")]
        Response<string[]> PrepareUnitForDispense(string colorantName, double quantity);
        
        [XmlRpcMethod(method: "cancelPreparedUnits")]
        Response<bool> CancelPreparedUnits();

        [XmlRpcMethod(method: "correctFillLevel")]
        Response<object[]> CorrectFillLevel(string colorantName, int circuitNumber, double newQuantity);

        [XmlRpcMethod(method: "dispenseAllPreparedUnits")]
        Response<bool> DispenseAllPreparedUnits();

        [XmlRpcMethod(method: "toggleSimulationMode")]
        Response<bool> ToggleSimulationMode(bool activate);
        
        [XmlRpcMethod("getNumberOfDispenserUnits")]
        PearlResponse<string[]> GetNumberOfDispenserUnits(bool fromFile = false);
    }
}
