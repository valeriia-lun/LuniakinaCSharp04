using System;

namespace Luniakina04.Tools.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($" Wrong email: {email}!!!")
        {

        }
    }
}