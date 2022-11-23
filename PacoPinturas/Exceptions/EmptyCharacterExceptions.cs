using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Exceptions
{
    internal class EmptyCharacterExceptions : Exception
    {
        public EmptyCharacterExceptions(string message) : base(message) { }
    }
}
