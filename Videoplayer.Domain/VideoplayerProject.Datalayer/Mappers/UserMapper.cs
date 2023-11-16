using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Datalayer.Models;

namespace VideoplayerProject.Datalayer.Mappers
{
    public static class UserMapper
    {
        public static Domain.Models.User MapToDomainModel(Datalayer.Models.Users user)
        {
            return new Domain.Models.User(user.Id, user.Username, user.Password);
        }

        public static Datalayer.Models.Users MapToDataEntity(Domain.Models.User user)
        {
            return new Datalayer.Models.Users
            {
                Username = user.Username,
                Password = user.Password,
                Id = user.Id,
            };
        }
    }
}
