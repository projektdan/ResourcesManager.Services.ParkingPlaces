using System;

namespace ResourcesManager.Services.Libraries.Exceptions
{
    public class ExceptionBase : Exception
    {
        public string Code { get; }

        protected ExceptionBase()
        {
        }

        protected ExceptionBase(string code)
        {
            this.Code = code;
        }

        protected ExceptionBase(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected ExceptionBase(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected ExceptionBase(Exception innerException, string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {
            this.Code = code;
        }
    }
}
