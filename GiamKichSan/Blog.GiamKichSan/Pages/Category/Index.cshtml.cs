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
    public class IndexModel : PageModel
    {
        public List<CategoryEntity> categoriesEntity { get; set; }
        private CategoryServices categoryServices { get; set; }
        public IndexModel(BlogDbContext context)
        {
            Common.CntGlobal.blogDbContext = context;
            categoryServices = new CategoryServices();
        }
        public void OnGet()
        {
            categoriesEntity = categoryServices.GetAll();
        }
    }
}
