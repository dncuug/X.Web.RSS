using System;
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
                throw new ArgumentException($"Value must be between 0 and 23: {value}", nameof(value));
            }

            _value = value;
        }
    }
}