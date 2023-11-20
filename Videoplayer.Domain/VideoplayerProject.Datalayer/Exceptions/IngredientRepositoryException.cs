using System;

namespace VideoplayerProject.Datalayer.Exceptions
{
    public class IngredientRepositoryException : Exception
    {
        public IngredientRepositoryException() { }

        public IngredientRepositoryException(string message) : base(message) { }

        public IngredientRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}