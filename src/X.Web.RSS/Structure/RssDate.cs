using System;
using System.Globalization;
using System.Xml.Serialization;

namespace X.Web.RSS.Structure;

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
        get { return _date.HasValue ? _date.Value.ToString() : String.Empty; }
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
                    throw new ArgumentException($"Unable to parse date: {value}", ex);
                }
            }

            Date = parseDate;
        }
    }

    [XmlText]
    public string DateStringISO8601
    {
        get
        {
            var result = Date.HasValue
                ? Date.Value.ToString("yyyy-MM-ddTHH:mm:ss.Z", CultureInfo.InvariantCulture)
                : DateString;
            
            return result;
        }
    }

    [XmlIgnore]
    public DateTime? Date
    {
        get { return _date; }
        set
        {
            if (value != null)
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException($"Date cannot be greater than today: {value}", nameof(value));
                }
            }

            _date = value;
        }
    }
}