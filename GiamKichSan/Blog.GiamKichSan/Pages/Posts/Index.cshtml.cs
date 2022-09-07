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
    public class IndexModel : PageModel
    {
        public List<PostModel> postsModel { get; set; }
        private PostServices postServices { get; set; }
        public IndexModel(BlogDbContext context)
        {
            Common.CntGlobal.blogDbContext = context;
            postServices = new PostServices();
        }
        public void OnGet()
        {
            postsModel = postServices.GetAll();
        }
    }
}
