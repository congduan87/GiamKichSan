using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TraCuu.GiamKichSan.Data;
using TraCuu.GiamKichSan.Model;
using TraCuu.GiamKichSan.Services;

namespace TraCuu.GiamKichSan.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public List<PersonCommunityModel> personCommunitiesModel { get; set; }
		private PersonCommunityServices personCommunityServices = new PersonCommunityServices();
		public bool IsNull { get; set; }
		public IndexModel(ILogger<IndexModel> logger, TraCuuDbContext context)
		{
			_logger = logger;
			Common.CntGlobal.traCuuDbContext = context;
		}

		public void OnGet(string term)
		{
			ViewData["Title"] = "người nổi tiếng";
			personCommunitiesModel = new List<PersonCommunityModel>();
			if (!string.IsNullOrWhiteSpace(term))
			{
				personCommunitiesModel = personCommunityServices.GetAll(x => x.IsShow && (x.Name.Contains(term) || x.Alias.Contains(term)));
				IsNull = personCommunitiesModel == null && personCommunitiesModel.Count == 0;
			}
		}
	}
}
