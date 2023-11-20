using System;

namespace VideoplayerProject.Datalayer.Exceptions
{
    public class UtensilRepositoryException : Exception
    {
        public UtensilRepositoryException() { }

        public UtensilRepositoryException(string message) : base(message) { }

        public UtensilRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}