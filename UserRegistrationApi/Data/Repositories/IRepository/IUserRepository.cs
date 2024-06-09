using UserRegistrationApi.Models;
using System.Collections.Generic;

namespace UserRegistrationApi.Data.Repositories.IRepository;
public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
    IEnumerable<User> GetAllUsersOrderedByUsername();
    IEnumerable<object> GetUsersGroupedByRole();
    void SaveChanges();
}