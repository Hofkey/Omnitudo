using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Entities;

namespace Omnitudo.API.Mappers
{
    public class CategoryCategoryDTOMapper : Mapper<Category, CategoryDTO>
    {
        public override Category ToSource(CategoryDTO target)
        {
            throw new NotImplementedException();
        }

        public override CategoryDTO ToTarget(Category source)
        {
            return new CategoryDTO
            {
                Id = source.Id,
                Title = source.Title
            };
        }
    }
}
