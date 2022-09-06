using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Data;
using Blog.GiamKichSan.Entities;
using Blog.GiamKichSan.Model;
using Blog.GiamKichSan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.GiamKichSan.Pages.Posts
{
    public class UpdateModel : PageModel
    {
        public List<CategoryEntity> categoriesEntity { get; set; }
        public PostModel postModel { get; set; }
        private CategoryServices categoryServices { get; set; }
        private PostServices postServices { get; set; }
        public UpdateModel(BlogDbContext context)
        {
            Common.CntGlobal.blogDbContext = context;
            categoryServices = new CategoryServices();
            postServices = new PostServices();
        }
        public void OnGet(int ID)
        {
            if (ID == 0)
            {
                ViewData["Title"] = "Thêm mới";
                postModel = new PostModel();
            }
            else
            {
                ViewData["Title"] = "Cập nhật";
                postModel = postServices.GetByID(ID);
            }
            categoriesEntity = categoryServices.GetAll();
        }
        public IActionResult OnPost(PostModel postModel)
        {
            this.postModel = postModel;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.postModel.ID != 0)
            {
                postServices.Edit(this.postModel);
            }
            else
            {
                postServices.Insert(this.postModel);
            }
            return RedirectToPage("");
        }
    }
}
