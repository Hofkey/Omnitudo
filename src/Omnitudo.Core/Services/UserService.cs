using Omnitudo.Core.Entities;
using Omnitudo.Core.Entities.NonDatabase;
using Omnitudo.Core.Exceptions;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Core.Services.Interfaces;
using Omnitudo.Shared.Security;

namespace Omnitudo.Core.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository { get; }

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool UserExists(Guid guid) => userRepository.GetById(guid) != null;

        public User GetById(Guid guid)
        {
            if (userRepository.GetById(guid) is User user)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException(typeof(User), guid);
            }
        }

        public List<User> GetAll()
        {
            return userRepository.Get(null).ToList();
        }

        public async Task Add(User newUser)
        {
            if (userRepository.Get(user => user.Email == newUser.Email).Any())
            {
                throw new DuplicateEntityException("User", "E-mail", newUser.Email);
            }

            await userRepository.Create(newUser);
        }

        public async Task Edit(Guid guid, EditUser editUser)
        {
            if (userRepository.GetById(guid) is User user)
            {
                user.UserName = editUser.UserName;
                user.Email = editUser.Email;
                user.Role = editUser.Role;

                await userRepository.Update(user);
            }
            else
            {
                throw new EntityNotFoundException(typeof(User), guid);
            }
        }

        public async Task EditPassword(Guid guid, UserPasswordChange passwordChange)
        {
            if (userRepository.GetById(guid) is User user)
            {
                if (PasswordHelper.IsValid(passwordChange.OldPassword, user.Password))
                {
                    user.Password = PasswordHelper.GetHash(passwordChange.NewPassword);

                    await userRepository.Update(user);
                }
                else
                {
                    throw new InvalidPasswordException("Invalid password for user.");
                }
            }
            else
            {
                throw new EntityNotFoundException(typeof(User), guid);
            }
        }

        public async Task Remove(Guid guid)
        {
            await userRepository.Delete(guid);
        }

    }
}
