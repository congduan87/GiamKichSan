using Blog.GiamKichSan.Data;
using Blog.GiamKichSan.Model;
using Blog.GiamKichSan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.GiamKichSan.Pages
{
	public class IndexModel : PageModel
	{
		public List<PostModel> postsModel { get; set; }
		public PostServices postServices { get; set; }
		public IndexModel(BlogDbContext context)
		{
			Common.CntGlobal.blogDbContext = context;
			postServices = new PostServices();
		}

		public void OnGet(int category = 3)
		{
			postsModel = postServices.GetAll(x => x.IDCategory == category);
		}
	}
}
