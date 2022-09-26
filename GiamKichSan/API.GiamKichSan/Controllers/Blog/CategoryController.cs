using API.GiamKichSan.Data.Blog;
using API.GiamKichSan.Entities.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
		public IEnumerable<CategoryEntity> Get()
		{
			return this.categoryData.GetAll();
		}
	}
}
