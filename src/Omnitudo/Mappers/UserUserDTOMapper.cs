using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Entities;

namespace Omnitudo.API.Mappers
{
    public class UserUserDTOMapper : Mapper<User, UserDTO>
    {
        public override User ToSource(UserDTO target)
        {
            throw new NotImplementedException();
        }

        public override UserDTO ToTarget(User source)
        {
            return new UserDTO
            {
                Id = source.Id,
                Email = source.Email,
                UserName = source.UserName,
                Role = source.Role
            };
        }
    }
}
