using API.GiamKichSan.Common;
using API.GiamKichSan.Data;
using API.GiamKichSan.Models.Search;
using API.GiamKichSan.Services.Search;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.GiamKichSan.Controllers.Blog
{
	[ApiController]
	[Route("Blog/[controller]")]
	public class CommunityController : Controller
	{
		private CommunityServices communityServices { get; set; }
		public CommunityController(GKSDbContext gKSDbContext)
		{
			CntGlobal.gKSDbContext = gKSDbContext;
			this.communityServices = new CommunityServices();
		}
		[HttpGet]
		public IEnumerable<CommunityModel> GetAll(string name = "")
		{
			return communityServices.GetAll(x => x.Name.Contains(name));
		}
		[HttpGet("{id}")]
		public CommunityModel GetDetail([FromRoute] int id)
		{
			return communityServices.GetByID(id);
		}
		[HttpPost]
		public int Insert(CommunityModel item)
		{
			return communityServices.Insert(item);
		}
		[HttpPut("{id}")]
		public bool Edit([FromRoute] int id, [FromBody] CommunityModel item)
		{
			return communityServices.Edit(item);
		}
		[HttpDelete]
		public bool Delete([FromRoute] int id)
		{
			return communityServices.Delete(id);
		}
	}
}
