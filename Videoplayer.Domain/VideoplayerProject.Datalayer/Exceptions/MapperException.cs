using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoplayerProject.Datalayer.Exceptions
{
    [Serializable]
    internal class MapperException : Exception
    {
        public MapperException()
        {
        }

        public MapperException(string? message) : base(message)
        {
        }

        public MapperException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
    
}
