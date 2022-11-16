using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Exceptions
{
    internal class PhoneException : Exception
    {
        public PhoneException(string message) : base(message) { }
    }
}
