using Omnitudo.Core.Entities;
using Omnitudo.Core.Entities.NonDatabase;

namespace Omnitudo.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task Add(User newUser);
        Task Edit(Guid guid, EditUser editUser);
        Task EditPassword(Guid guid, UserPasswordChange passwordChange);
        List<User> GetAll();
        User GetById(Guid guid);
        Task Remove(Guid guid);
        bool UserExists(Guid guid);
    }
}