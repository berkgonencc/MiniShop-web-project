using System;
using System.Runtime.Serialization;

namespace MiniShopAPI.Application.Exceptions
{
	public class AuthenticationErrorException : Exception
	{
		public AuthenticationErrorException() : base("Authentication Error!")
		{
		}

        public AuthenticationErrorException(string message) : base(message)
        {
        }

        public AuthenticationErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

