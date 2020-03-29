using System;


namespace Luniakina04.Tools.Exceptions
{
    internal class PersonTooOldException : Exception
    {
        public PersonTooOldException() : base($"Wrong date. You cant be that old!!!")
        {

        }
    }
}

