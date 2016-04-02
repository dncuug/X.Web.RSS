namespace RSS.Exceptions
{
    #region Using Directives

    using System;
    using System.Runtime.Serialization;

    #endregion

    public class RSSParameterException : Exception
    {
        #region Constants and Fields

        private const string MessageText = "RSSParameterException field '{0}', value '{1}'";

        #endregion

        #region Constructors and Destructors

        public RSSParameterException(string field, object value)
            : base(string.Format(MessageText, field, value))
        {
            this.Field = field;
            this.Value = value;
        }

        public RSSParameterException(string field, object value, Exception innerException)
            : base(string.Format(MessageText, field, value), innerException)
        {
            this.Field = field;
            this.Value = value;
        }

        protected RSSParameterException(SerializationInfo info, StreamingContext context, string field, object value)
            : base(info, context)
        {
            this.Field = field;
            this.Value = value;
        }

        #endregion

        #region Properties

        public string Field { get; }

        public object Value { get; }

        #endregion
    }
}