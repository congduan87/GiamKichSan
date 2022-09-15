using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net;

namespace Blog.GiamKichSan.Pages
{
	public class CustPageModel : PageModel
	{
		#region IPAddress
		private string _Id { get; set; }
		private string _LocalIpAddress { get; set; }
		private string _InternetIpAddress { get; set; }
		private string _RemoteIpAddress { get; set; }
		private string _Host { get; set; }

		public string Id
		{
			get
			{
				if (_Id == null)
				{
					_Id = HttpContext.Connection.Id;
				}
				return _Id;
			}
		}
		public string LocalIpAddress
		{
			get
			{
				if (_LocalIpAddress == null)
				{
					_LocalIpAddress = HttpContext.Connection.LocalIpAddress.ToString();
				}
				return _LocalIpAddress;
			}
		}
		public string InternetIpAddress
		{
			get
			{
				if (_InternetIpAddress == null)
				{
					string address = "";
					WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
					using (WebResponse response = request.GetResponse())
					using (StreamReader stream = new StreamReader(response.GetResponseStream()))
					{
						address = stream.ReadToEnd();
					}

					int first = address.IndexOf("Address: ") + 9;
					int last = address.LastIndexOf("</body>");
					address = address.Substring(first, last - first);

					_InternetIpAddress = address;
				}
				return _InternetIpAddress;
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
		public CustPageModel() : base()
		{

		}
	}
}
