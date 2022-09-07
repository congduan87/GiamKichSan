using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Data;
using Blog.GiamKichSan.Model;
using Blog.GiamKichSan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.GiamKichSan.Pages.Posts
{
    public class ViewModel : PageModel
    {
        private PostServices postServices { get; set; }
        public PostModel postModel { get; set; }
        public ViewModel(BlogDbContext context)
        {
            Common.CntGlobal.blogDbContext = context;
            postServices = new PostServices();
        }
        public void OnGet(int ID)
        {
            if (ID == 0)
            {
                postModel = new PostModel();
            }
            else
            {
                postModel = postServices.GetByID(ID)??new PostModel();
            }
        }
    }
}
