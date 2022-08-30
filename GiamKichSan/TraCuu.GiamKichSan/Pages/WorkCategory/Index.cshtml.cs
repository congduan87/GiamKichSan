using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TraCuu.GiamKichSan.Data;
using TraCuu.GiamKichSan.Entities;
using TraCuu.GiamKichSan.Services;

namespace TraCuu.GiamKichSan.Pages.WorkCategory
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public WorkCategoryEntity workCategoryEntity { get; set; }
		private WorkCategoryServices workCategoryServices = new WorkCategoryServices();
		public IndexModel(ILogger<IndexModel> logger, TraCuuDbContext context)
		{
			_logger = logger;
			Common.CntGlobal.traCuuDbContext = context;
		}
		public void OnGet(int ID)
		{
			if (ID == 0)
				workCategoryEntity = new WorkCategoryEntity();
			else
				workCategoryEntity = workCategoryServices.GetByID(ID);
		}
		public IActionResult OnPost(WorkCategoryEntity workCategoryEntity)
		{
			this.workCategoryEntity = workCategoryEntity;
			if (!ModelState.IsValid)
			{
				return Page();
			}		
			if (this.workCategoryEntity.ID != 0)
			{
				workCategoryServices.Edit(this.workCategoryEntity);
			}
			else
			{
				workCategoryServices.Insert(this.workCategoryEntity);
			}
			return RedirectToPage("");
		}
	}
}
