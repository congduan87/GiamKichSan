using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TraCuu.GiamKichSan.Common;
using TraCuu.GiamKichSan.Data;
using TraCuu.GiamKichSan.Entities;
using TraCuu.GiamKichSan.Model;
using TraCuu.GiamKichSan.Services;

namespace TraCuu.GiamKichSan.Pages.FamousPeople
{
	public class CreateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public PersonCommunityModel personCommunityModel { get; set; }
		public List<WorkCategoryEntity> workCategoriesEntity { get; set; }
		private PersonCommunityServices personCommunityServices = new PersonCommunityServices();
        private WorkCategoryServices workCategoryServices = new WorkCategoryServices();
        [DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "*.png,*.jpg,*.jpeg,*.gif")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public CreateModel(ILogger<IndexModel> logger, TraCuuDbContext context)
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
            personCommunityModel.IsShow = false;
            this.personCommunityModel = personCommunityModel;
            workCategoriesEntity = workCategoryServices.GetAll();
			if (!ModelState.IsValid)
			{
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        var key = modelStateKey;
                        var errorMessage = error.ErrorMessage;
                    }
                }
                return Page();
			}
            personCommunityModel.Image = string.Join(", ", Helpers.UploadFiles(FileUploads, personCommunityModel.WorkCategoryID.ToString()));

            if (personCommunityModel.ID != 0)
			{
                personCommunityServices.Edit(personCommunityModel);
            }
            else
			{
                personCommunityServices.Insert(personCommunityModel);
            }
            return RedirectToPage("/Index");
        }
    }
}
