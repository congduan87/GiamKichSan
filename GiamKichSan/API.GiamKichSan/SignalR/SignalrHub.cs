using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.SignalR
{
	public interface IHubClient
	{
		Task BroadcastMessage(MessageModel msg);
	}

	[EnableCors("AllowOrigin")]
	public class SignalrHub : Hub<IHubClient>
	{
		[EnableCors("AllowOrigin")]
		public async Task BroadcastMessage(MessageModel msg)
		{
			await Clients.All.BroadcastMessage(msg);
		}
	}
}
