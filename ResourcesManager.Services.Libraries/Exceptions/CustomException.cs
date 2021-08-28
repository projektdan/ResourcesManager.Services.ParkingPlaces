using System;

namespace ResourcesManager.Services.Libraries.Exceptions
{
    public class CustomException : ExceptionBase
    {
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
    }
}
