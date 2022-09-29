using API.GiamKichSan.Entities.Blog;

namespace API.GiamKichSan.Models.Blog
{
	public class CategoryModel : CategoryEntity
	{
		public CategoryModel()
		{

		}
		public static CategoryModel ConvertFromEntity(CategoryEntity entity)
		{
			return entity as CategoryModel;
		}
	}
}
