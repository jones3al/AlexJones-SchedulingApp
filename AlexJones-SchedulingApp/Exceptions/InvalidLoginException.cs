using System;

namespace AlexJones_SchedulingApp.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message) : base (message) { }
    }
}
