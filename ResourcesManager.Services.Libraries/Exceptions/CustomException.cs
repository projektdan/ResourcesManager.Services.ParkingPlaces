using System;
using System.Net;

namespace ResourcesManager.Services.Libraries.Exceptions
{
    public class CustomException : ExceptionBase
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public CustomException()
        {
        }

        public CustomException(string code) : base(code)
        {
        }

        public CustomException(string message, params object[] args) : base(string.Empty, message, args)
        {
        }

        public CustomException(string code, string message, params object[] args) : base(code, message, args)
        {
        }

        public CustomException(Exception innerException, string code, string message, params object[] args) : base(innerException, code, string.Format(message, args))
        {
        }

        public CustomException WithCode(HttpStatusCode code)
        {
            this.HttpStatusCode = code;
            return this;
        }
    }
}
