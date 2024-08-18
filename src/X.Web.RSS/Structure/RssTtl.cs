using System.Xml.Serialization;
using X.Web.RSS.Validators;

namespace X.Web.RSS.Structure;

public class RssTtl
{
    private int? _ttl;

    public RssTtl()
    {
    }

    public RssTtl(int ttl)
    {
        TTL = ttl;
    }


    [XmlText]
    public int? TTL
    {
        get { return _ttl; }
        set
        {
            new TTLValidator().Validate(value);

            if (value == 0)
            {
                _ttl = null;
            }
            else
            {
                _ttl = value;
            }
        }
    }
}