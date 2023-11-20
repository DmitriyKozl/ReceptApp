using System.Runtime.Serialization;

namespace VideoplayerProject.Domain.Exceptions
{
    public class TimestampException : Exception
    {
        public TimestampException()
        {
        }

        public TimestampException(string? message) : base(message)
        {
        }

        public TimestampException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}