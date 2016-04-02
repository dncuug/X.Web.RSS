namespace RSS.Enumerators
{
    #region Using Directives

    using System.Xml.Serialization;

    using RSS.Exceptions;

    #endregion

    public class Hour
    {
        #region Constants and Fields

        private byte _value;

        #endregion

        #region Constructors and Destructors

        public Hour()
        {
        }

        public Hour(byte newValue)
        {
            this._value = newValue;
        }

        #endregion

        #region Properties

        [XmlText]
        public byte Value
        {
            get
            {
                return this._value;
            }

            set
            {
                if (value < 0 || value > 23)
                {
                    throw new RSSParameterException("hour", value);
                }

                this._value = value;
            }
        }

        #endregion
    }
}