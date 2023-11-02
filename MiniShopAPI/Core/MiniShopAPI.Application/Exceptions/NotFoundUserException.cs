﻿using System;
using System.Runtime.Serialization;

namespace MiniShopAPI.Application.Exceptions
{
	public class NotFoundUserException : Exception
	{
		public NotFoundUserException() : base("Username or Password wrong!")
		{
		}

        public NotFoundUserException(string message) : base(message)
        {
        }

        public NotFoundUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

