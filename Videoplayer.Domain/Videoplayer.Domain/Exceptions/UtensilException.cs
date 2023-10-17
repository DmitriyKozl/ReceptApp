using System.Runtime.Serialization;

namespace VideoplayerProject.Domain.Exceptions
{
    [Serializable]
    internal class UtensilException : Exception
    {
        public UtensilException()
        {
        }

        public UtensilException(string? message) : base(message)
        {
        }

        public UtensilException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}