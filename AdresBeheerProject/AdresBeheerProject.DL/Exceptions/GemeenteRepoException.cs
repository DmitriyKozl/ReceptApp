using System.Runtime.Serialization;

namespace AdresBeheerProject.DL.Exceptions
{
    [Serializable]
    internal class GemeenteRepoException : Exception
    {
        public GemeenteRepoException()
        {
        }

        public GemeenteRepoException(string? message) : base(message)
        {
        }

        public GemeenteRepoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GemeenteRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}