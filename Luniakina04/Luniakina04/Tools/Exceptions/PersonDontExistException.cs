using System;


namespace Luniakina04.Tools.Exceptions
{
    internal class PersonDontExistException : Exception
    {
        public PersonDontExistException() : base($"Wrong datw You don't exist yet!QQ")
        {

        }
    }
}
