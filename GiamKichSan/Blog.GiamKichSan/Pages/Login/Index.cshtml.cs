using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.GiamKichSan.Pages.Login
{
    public class IndexModel : PageModel
    {
		public string Email { get; set; }
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string email, string password)
        {
            this.Email = email;
            this.Password = password;
            if (Email == "duanvc2811@gmail.com" && Password == "LanThuNhat")
			{
                ViewData["Account"] = Email;
                return RedirectToPage("/Index");
			}
            ViewData["Account"] = null;
            return Page();
        }
    }
}
