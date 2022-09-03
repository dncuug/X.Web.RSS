using System;
using System.Xml.Serialization;
using X.Web.RSS.Exceptions;

namespace X.Web.RSS.Structure.Validators;

public class RssTtl
{

    private int _ttl;

    private string _ttlString;


    public RssTtl()
    {
    }

    public RssTtl(string ttl)
    {
        TTLString = ttl;
    }

    public RssTtl(int ttl)
    {
        TTL = ttl;
    }


    [XmlIgnore]
    public int TTL
    {
        get
        {
            return _ttl;
        }
        set
        {
            if (value < 0)
            {
                throw new RSSParameterException($"{this.GetType()}.ttl", value);
            }

            if (value != 0)
            {
                _ttl = value;
                _ttlString = _ttl.ToString();
            }
            else
            {
                _ttl = 0;
                _ttlString = null;
            }
        }
    }

    [XmlText]
    public string TTLString
    {
        get
        {
            return _ttlString;
        }

        set
        {
            int parseTtl = 0;
            
            if (value != null)
            {
                try
                {
                    parseTtl = int.Parse(value);
                }
                catch (Exception ex)
                {
                    throw new RSSParameterException("ttl", value, ex);
                }
            }

            TTL = parseTtl;
        }
    }
}