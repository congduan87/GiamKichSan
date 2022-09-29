using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Net;

namespace GiamKichSan.Pages
{
	public class CustPageModel : PageModel
	{
		#region IPAddress
		private string _IdRazorPage { get; set; }
		private string _SeverIpAddress { get; set; }
		private string _RemoteIpAddress { get; set; }
		private string _Host { get; set; }

		public string IdRazorPage
		{
			get
			{
				if (_IdRazorPage == null)
				{
					_IdRazorPage = HttpContext.Connection.Id;
				}
				return _IdRazorPage;
			}
		}
		public string SeverIpAddress
		{
			get
			{
				if (_SeverIpAddress == null)
				{
					_SeverIpAddress = HttpContext.Connection.LocalIpAddress.ToString();
				}
				return _SeverIpAddress;
			}
		}
		public string RemoteIpAddress
		{
			get
			{
				if (_RemoteIpAddress == null)
				{
					_RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
				}
				return _RemoteIpAddress;
			}
		}
		public string Host
		{
			get
			{
				if (_Host == null)
				{
					_Host = HttpContext.Request.Host.Host;
				}
				return _Host;
			}
		}
		#endregion

		#region Cookies
		public string Token
		{
			get
			{
				return HttpContext.Request.Cookies["Token"].ToString();
			}
			set
			{
				HttpContext.Response.Cookies.Append("Token", value, new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddDays(15) });
			}
		}

		#endregion

		public CustPageModel() : base()
		{

		}
	}
}
