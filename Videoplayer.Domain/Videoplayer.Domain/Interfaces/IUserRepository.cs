using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoplayerProject.Domain.Interfaces
{
    public interface IUserRepository
    {
        public bool Login(string username, string password);
    }   
}
