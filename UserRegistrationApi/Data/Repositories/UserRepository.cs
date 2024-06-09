// UserRepository.cs
using System.Collections.Generic;
using System.Linq;
using UserRegistrationApi.Data.Repositories.IRepository;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserRegistrationContext _context;

        public UserRepository(UserRegistrationContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllUsersOrderedByUsername()
        {
            return _context.Users.OrderBy(u => u.Username).ToList();
        }

        public IEnumerable<object> GetUsersGroupedByRole()
        {
            return _context.Users
                .GroupBy(u => u.Role.RoleName)
                .Select(g => new { Role = g.Key, Users = g.ToList() })
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
