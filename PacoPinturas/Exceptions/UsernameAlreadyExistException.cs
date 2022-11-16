using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Exceptions
{
    internal class UsernameAlreadyExistException : Exception
    {
        public UsernameAlreadyExistException(string message) : base(message) { }
    }
}
