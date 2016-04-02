namespace RSS.Structure.Validators
{
    #region Using Directives

    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    using RSS.Exceptions;

    #endregion

    public class RssEmail
    {
        #region Constants and Fields

        private readonly Regex _emailReg =
            new Regex(
                "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
                RegexOptions.IgnoreCase);

        private string _email;

        #endregion

        #region Constructors and Destructors

        public RssEmail()
        {
        }

        public RssEmail(string email)
        {
            this.Email = email;
        }

        #endregion

        #region Properties

        [XmlText]
        public string Email
        {
            get
            {
                return this._email;
            }

            set
            {
                if (value != null && !_emailReg.IsMatch(value))
                {
                    throw new RSSParameterException("email", value);
                }

                this._email = value;
            }
        }

        #endregion
    }
}