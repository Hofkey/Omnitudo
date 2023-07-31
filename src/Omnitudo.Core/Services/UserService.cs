using Omnitudo.Core.Entities;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;

namespace Omnitudo.Core.Services
{
    public class UserService
    {
        private IRepository<User> userRepository { get; }

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

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
            return userRepository.Get(user => user.Id != Guid.Empty).ToList();
        }

        public async Task Add(User user)
        {
            if (userRepository.Get(_user => _user.Email == user.Email).Any())
            {
                throw new DuplicateEntityException("User", "E-mail", user.Email);
            }

            await userRepository.Create(user);
        }
    }
}
