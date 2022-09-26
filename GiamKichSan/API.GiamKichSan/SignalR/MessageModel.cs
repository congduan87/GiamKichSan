using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.SignalR
{
	public class MessageModel
	{
		public string Timestamp { get; set; }
		public string From { get; set; }
		public string Code { get; set; }
		public string Message { get; set; }
	}
}
