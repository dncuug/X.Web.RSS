using System;
using System.Globalization;
using System.Xml.Serialization;
using X.Web.RSS.Exceptions;

namespace X.Web.RSS.Structure.Validators
{
    public class RssDate
    {
        #region Constants and Fields

        private string dateString;
        private DateTime? date;

        #endregion

        #region Constructors and Destructors

        public RssDate()
        {
        }

        public RssDate(string date)
        {
            this.DateString = date;
        }

        public RssDate(DateTime? date)
        {
            this.Date = date;
        }

        #endregion

        #region Properties

        [XmlText]
        public string DateString
        {
            get
            {
                return this.dateString;
            }

            set
            {
                DateTime? parseDate = null;
                if (value != null)
                {
                    try
                    {
                        parseDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex)
                    {
                        throw new RSSParameterException("date", value, ex);
                    }
                }

                this.Date = parseDate;
            }
        }

        [XmlText]
        public string DateStringISO8601
        {
            get
            {
                return Date.HasValue
                           ? Date.Value.ToString("yyyy-MM-ddTHH:mm:ss.fK", CultureInfo.InvariantCulture)
                           : dateString;
            }


        }

        [XmlIgnore]
        public DateTime? Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value != null)
                {
                    if (value > DateTime.Now)
                    {
                        throw new RSSParameterException("newDate", value);
                    }

                    this.date = value;
                    this.dateString = this.date.Value.ToString("R");
                }
                else
                {
                    this.date = null;
                    this.dateString = null;
                }
            }
        }

        #endregion
    }
}