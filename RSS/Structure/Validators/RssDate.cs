namespace RSS.Structure.Validators
{
    #region Using Directives

    using System;
    using System.Globalization;
    using System.Xml.Serialization;

    using RSS.Exceptions;

    #endregion

    public class RssDate
    {
        #region Constants and Fields

        private string _dateString;
        private DateTime? _date;

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
                return this._dateString;
            }

            set
            {
                DateTime? parseDate = null;
                if (value != null)
                {
                    try
                    {
                        parseDate = DateTime.ParseExact(value, "R", CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex)
                    {
                        throw new RSSParameterException("date", value, ex);
                    }
                }

                this.Date = parseDate;
            }
        }

        [XmlIgnore]
        public DateTime? Date
        {
            get
            {
                return this._date;
            }

            set
            {
                if (value != null)
                {
                    if (value > DateTime.Now)
                    {
                        throw new RSSParameterException("newDate", value);
                    }

                    this._date = value;
                    this._dateString = this._date.Value.ToString("R");
                }
                else
                {
                    this._date = null;
                    this._dateString = null;
                }
            }
        }

        #endregion
    }
}