using System;
using System.Linq;
using CookComputing.XmlRpc;

namespace pearls.PearlsResponses;

public class PearlResponse<T>
{
    [XmlRpcMember("service")] public string MethodName;

    [XmlRpcMember("r")] public T Data;

    [XmlRpcMember("errType"), XmlRpcMissingMapping(MappingAction.Ignore)]
    public string ErrorType;

    [XmlRpcMember("errDescription"), XmlRpcMissingMapping(MappingAction.Ignore)]
    public string ErrorDescription;

    [XmlRpcMember("error"), XmlRpcMissingMapping(MappingAction.Ignore)]
    public string Error;

    [XmlRpcMember("traceback"), XmlRpcMissingMapping(MappingAction.Ignore)]
    public string StackTrace;
}
