using API.GiamKichSan.Models;
using API.GiamKichSan.Services.Search;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.GiamKichSan.Controllers.Blog
{
	[ApiController]
	[Route("Blog/[controller]")]
	public class ConstController : Controller
	{
		private ConstServices constServices { get; set; }
		public ConstController()
		{
			constServices = new ConstServices();
		}
		[HttpGet]
		public IEnumerable<ConstModel> GetMediaType()
		{
			return constServices.GetAllMediaType();
		}
	}
}
