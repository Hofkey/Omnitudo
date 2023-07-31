using Omnitudo.Core.Entities;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Infrastructuur.Database;
using Omnitudo.Shared.Security;

namespace Omnitudo.Infrastructuur.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task Create(User entity)
        {
            if (Get(x => x.Email == entity.Email).Any())
            {
                throw new DuplicateEntityException("User", "Email", "User already exists!");
            }

            entity.Password = PasswordHelper.GetHash(entity.Password);

            await base.Create(entity);
        }

        public User? ValidatePassword(string email, string password)
        {
            var user = Get(x => x.Email == email).SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            PasswordHelper.IsValid(password, user.Password);

            return user;
        }
    }
}
