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
	public class CommunityMediaController : Controller
	{
		private CommunityMediaServices communityMediaServices { get; set; }
		public CommunityMediaController(GKSDbContext gKSDbContext)
		{
			CntGlobal.gKSDbContext = gKSDbContext;
			communityMediaServices = new CommunityMediaServices();
		}
		[HttpGet]
		public IEnumerable<CommunityMediaModel> GetAll(string name = "")
		{
			return communityMediaServices.GetAll(x => x.Name.Contains(name));
		}
		[HttpGet("{id}")]
		public CommunityMediaModel GetDetail([FromRoute] int id)
		{
			return communityMediaServices.GetByID(id);
		}
		[HttpPost]
		public int Insert(CommunityMediaModel item)
		{
			return communityMediaServices.Insert(item);
		}
		[HttpPut("{id}")]
		public bool Edit([FromRoute] int id, [FromBody] CommunityMediaModel item)
		{
			return communityMediaServices.Edit(item);
		}
		[HttpDelete("{id}")]
		public bool Delete([FromRoute] int id)
		{
			return communityMediaServices.Delete(id);
		}
	}
}
