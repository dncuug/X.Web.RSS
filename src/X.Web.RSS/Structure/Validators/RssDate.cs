using System;
using System.Globalization;
using System.Xml.Serialization;
using X.Web.RSS.Exceptions;

namespace X.Web.RSS.Structure.Validators;

public class RssDate
{
    private DateTime? _date;
        
    public RssDate()
    {
    }

    public RssDate(string date)
    {
        DateString = date;
    }

    public RssDate(DateTime? date)
    {
        Date = date;
    }


    [XmlText]
    public string DateString
    {
        get
        {
            return _date.HasValue ? _date.Value.ToString() : String.Empty;
        }
        set
        {
            DateTime? parseDate = null;
            
            if (!String.IsNullOrEmpty(value))
            {
                try
                {
                    parseDate = DateTime.Parse(value);
                }
                catch (Exception ex)
                {
                    throw new RSSParameterException("date", value, ex);
                }
            }

            Date = parseDate;
        }
    }

    [XmlText]
    public string DateStringISO8601 =>
        Date.HasValue
            ? Date.Value.ToString("yyyy-MM-ddTHH:mm:ss.Z", CultureInfo.InvariantCulture)
            : DateString;

    [XmlIgnore]
    public DateTime? Date
    {
        get
        {
            return _date;
        }
        set
        {
            if (value != null)
            {
                if (value > DateTime.Now)
                {
                    throw new RSSParameterException("newDate", value);
                }
            }

            _date = value;
        }
    }
}