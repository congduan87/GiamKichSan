using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TraCuu.GiamKichSan.Data;
using TraCuu.GiamKichSan.Entities;
using TraCuu.GiamKichSan.Model;
using TraCuu.GiamKichSan.Services;

namespace TraCuu.GiamKichSan.Pages.FamousPeople
{
    public class UpdateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public PersonCommunityModel personCommunityModel { get; set; }
        public List<WorkCategoryEntity> workCategoriesEntity { get; set; }
        private PersonCommunityServices personCommunityServices = new PersonCommunityServices();
        private WorkCategoryServices workCategoryServices = new WorkCategoryServices();
        public UpdateModel(ILogger<IndexModel> logger, TraCuuDbContext context)
        {
            _logger = logger;
            Common.CntGlobal.traCuuDbContext = context;
        }
        public void OnGet(int ID = 0)
        {
            workCategoriesEntity = workCategoryServices.GetAll();
            if (ID == 0)
                personCommunityModel = new PersonCommunityModel();
            else
                personCommunityModel = personCommunityServices.GetByID(ID);
        }
        public IActionResult OnPost(PersonCommunityModel personCommunityModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var data = new PersionCommunityData();
            var persion = data.GetByID(personCommunityModel.ID);

            if (persion.ID != 0)
            {
                persion.IsShow = true;
                data.Edit(persion);
            }            
            return RedirectToPage("./Index");
        }
    }
}
