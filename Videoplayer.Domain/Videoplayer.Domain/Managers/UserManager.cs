using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;


namespace VideoplayerProject.Domain.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepo;
        public bool Login(string username, string password)
        {
            return _userRepo.Login(username, password);
        }
    }
}
