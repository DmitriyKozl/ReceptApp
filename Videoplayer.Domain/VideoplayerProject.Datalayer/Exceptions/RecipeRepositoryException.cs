using System.Runtime.Serialization;

namespace VideoplayerProject.Datalayer.Exceptions
{
    [Serializable]
    public class RecipeRepositoryException : Exception
    {
        public RecipeRepositoryException()
        {
        }

        public RecipeRepositoryException(string? message) : base(message)
        {
        }

        public RecipeRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecipeRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}