using API.GiamKichSan.Common;
using API.GiamKichSan.Data;
using API.GiamKichSan.Models.Blog;
using API.GiamKichSan.Param.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.GiamKichSan.Controllers.Blog
{
	[ApiController]
	[Route("Blog/[controller]")]
	public class CategoryController : ControllerBase
	{
		private CategoryServices categoryServices { get; set; }
		public CategoryController(GKSDbContext gKSDbContext)
		{
			CntGlobal.gKSDbContext = gKSDbContext;
			this.categoryServices = new CategoryServices();
		}
		[HttpGet]
		public IEnumerable<CategoryModel> GetAll(string name = "")
		{
			return categoryServices.GetAll(x => x.Name.Contains(name));
		}
		[HttpGet("{id}")]
		public CategoryModel GetDetail([FromRoute] int id)
		{
			return categoryServices.GetByID(id);
		}
		[HttpPost]
		public int Insert(CategoryModel item)
		{
			return categoryServices.Insert(item);
		}
		[HttpPut("{id}")]
		public bool Edit([FromRoute] int id, [FromBody] CategoryModel item)
		{
			return categoryServices.Edit(item);
		}
		[HttpDelete]
		public bool Delete([FromRoute] int id)
		{
			return categoryServices.Delete(id);
		}
	}
}
