using System.Runtime.Serialization;

namespace VideoplayerProject.Domain.Exceptions
{
    [Serializable]
    internal class RecipeException : Exception
    {
        public RecipeException()
        {
        }

        public RecipeException(string? message) : base(message)
        {
        }

        public RecipeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}