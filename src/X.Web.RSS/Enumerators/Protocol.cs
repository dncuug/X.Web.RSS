using JetBrains.Annotations;

namespace X.Web.RSS.Enumerators;

// ToDo: rename elements and check xml-rpc
[PublicAPI]
public enum Protocol
{
    soap, // "soap",
    xmlrpc // "xml-rpc"
}