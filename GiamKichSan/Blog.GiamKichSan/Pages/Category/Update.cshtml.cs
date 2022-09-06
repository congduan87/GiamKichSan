using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Data;
using Blog.GiamKichSan.Entities;
using Blog.GiamKichSan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.GiamKichSan.Pages.Category
{
    public class UpdateModel : PageModel
    {
        public CategoryEntity categoryEntity { get; set; }
        public List<CategoryEntity> parentcategoryEntity { get; set; }
        private CategoryServices categoryServices { get; set; }
        public UpdateModel(BlogDbContext context)
        {
            Common.CntGlobal.blogDbContext = context;
            categoryServices = new CategoryServices();
        }
        public void OnGet(int ID)
        {
            if (ID == 0)
			{
                ViewData["Title"] = "Thêm mới";
                categoryEntity = new CategoryEntity();
                parentcategoryEntity = categoryServices.GetAll();
            }                
            else
			{
                ViewData["Title"] = "Cập nhật";
                categoryEntity = categoryServices.GetByID(ID);
                parentcategoryEntity = categoryServices.GetAll(x=>x.ID != ID);
            }                
        }
        public IActionResult OnPost(CategoryEntity categoryEntity)
        {
            this.categoryEntity = categoryEntity;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.categoryEntity.ID != 0)
            {
                categoryServices.Edit(this.categoryEntity);
            }
            else
            {
                categoryServices.Insert(this.categoryEntity);
            }
            return RedirectToPage("");
        }
    }
}
