namespace RSS.Structure.Validators
{
    #region Using Directives

    using System;
    using System.Xml.Serialization;

    using RSS.Exceptions;

    #endregion

    public class RssTtl
    {
        #region Constants and Fields

        private int _ttl;

        private string _ttlString;

        #endregion

        #region Constructors and Destructors

        public RssTtl()
        {
        }

        public RssTtl(string ttl)
        {
            this.TTLString = ttl;
        }

        public RssTtl(int ttl)
        {
            this.TTL = ttl;
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public int TTL
        {
            get
            {
                return this._ttl;
            }

            set
            {
                if (value < 0)
                {
                    throw new RSSParameterException(string.Format("{0}.ttl", this.GetType()), value);
                }

                if (value != 0)
                {
                    this._ttl = value;
                    this._ttlString = this._ttl.ToString();
                }
                else
                {
                    this._ttl = 0;
                    this._ttlString = null;
                }
            }
        }

        [XmlText]
        public string TTLString
        {
            get
            {
                return this._ttlString;
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

                this.TTL = parseTtl;
            }
        }

        #endregion
    }
}