using System;


namespace Luniakina04.Tools.Exceptions
{
    internal class InvalidSurnameException : Exception
    {
        public InvalidSurnameException(string surname) : base($"Wrong lastname!!!")
        {

        }
    }
}

