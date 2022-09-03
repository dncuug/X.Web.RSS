using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace X.Web.RSS.Exceptions;

public class RSSParameterException : Exception
{
    private const string MessageText = "RSSParameterException field '{0}', value '{1}'";

    public RSSParameterException(string field, object value)
        : base(string.Format(MessageText, field, value))
    {
        Field = field;
        Value = value;
    }

    public RSSParameterException(string field, object value, Exception innerException)
        : base(string.Format(MessageText, field, value), innerException)
    {
        Field = field;
        Value = value;
    }

    protected RSSParameterException(SerializationInfo info, StreamingContext context, string field, object value)
        : base(info, context)
    {
        Field = field;
        Value = value;
    }

    [PublicAPI]
    public string Field { get; }

    [PublicAPI]
    public object Value { get; }
}