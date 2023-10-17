using System.Runtime.Serialization;

namespace AdresBeheerProject.BL.Exceptions
{
    [Serializable]
    internal class GemeenteException : Exception
    {
        public GemeenteException()
        {
        }

        public GemeenteException(string? message) : base(message)
        {
        }

        public GemeenteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}