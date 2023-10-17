using System.Runtime.Serialization;

namespace VideoplayerProject.Domain.Exceptions
{
    [Serializable]
    internal class IngredientException : Exception
    {
        public IngredientException()
        {
        }

        public IngredientException(string? message) : base(message)
        {
        }

        public IngredientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}