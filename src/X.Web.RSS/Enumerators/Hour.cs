using X.Web.RSS.Exceptions;
using System.Xml.Serialization;

namespace X.Web.RSS.Enumerators;

public class Hour
{
    private byte _value;
        
    public Hour()
    {
    }

    public Hour(byte newValue)
    {
        _value = newValue;
    }

    [XmlText]
    public byte Value
    {
        get => _value;
        set
        {
            if (value < 0 || value > 23)
            {
                throw new RSSParameterException("hour", value);
            }

            _value = value;
        }
    }
}