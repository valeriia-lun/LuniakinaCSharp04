using System;

namespace Luniakina04.Tools.Exceptions
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException(string name) : base($" Wrong name!!!")
        {

        }
    }
}
