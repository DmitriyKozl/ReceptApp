using VideoplayerProject.Datalayer.Data;
using VideoplayerProject.Domain.Interfaces;

namespace VideoplayerProject.Datalayer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool Login(string username, string password)
    {
        if (_context.Users.FirstOrDefault(u => u.Username == username && u.Password == password) != null)
        {
            return true;
        }
        return false;
    }
}