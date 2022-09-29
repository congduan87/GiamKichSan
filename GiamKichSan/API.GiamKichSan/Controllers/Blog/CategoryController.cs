using API.GiamKichSan.Data.Blog;
using API.GiamKichSan.Entities.Blog;
using API.GiamKichSan.Models.Blog;
using API.GiamKichSan.Param.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Controllers.Blog
{
	[ApiController]
	[Route("Blog/[controller]")]
	public class CategoryController : ControllerBase
	{
		private CategoryData categoryData { get; set; }
		public CategoryController()
		{
			this.categoryData = new CategoryData();
		}
		[HttpGet]
		public IEnumerable<CategoryModel> GetAll(CategoryTerm param)
		{
			return this.categoryData.GetAll(x => (param.ID.Equals(0) || x.ID.Equals(param.ID)) && (param.IDParent == null || x.IDParent.Equals(param.IDParent)) && (param.Name == "" || x.Name.Contains(param.Name))).Select(x => CategoryModel.ConvertFromEntity(x));
		}
		[HttpGet("{id}")]
		public CategoryModel GetDetail([FromRoute] int id)
		{
			return this.categoryData.GetAll(x => x.ID == id).Select(x => CategoryModel.ConvertFromEntity(x)).FirstOrDefault();
		}
		[HttpPost]
		public int Insert(CategoryEntity item)
		{
			var entity = new CategoryEntity()
			{

			};
			return this.categoryData.Insert(item);
		}
		[HttpPut("{id}")]
		public bool Edit([FromRoute] int id, [FromBody] CategoryEntity item)
		{
			return this.categoryData.Edit(item);
		}
		[HttpDelete]
		public bool Delete([FromRoute] int id)
		{
			return this.categoryData.Delete(id);
		}
	}
}
