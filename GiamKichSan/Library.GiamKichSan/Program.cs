using Library.GiamKichSan.GenFunction;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Library.GiamKichSan
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			IGenFunctionInFolder iGen = new GenFunctionInFolder();
			iGen.Generate(@"E:\duanvc\VisualBasic");

			Console.ReadLine();



			//var connection = new HubConnectionBuilder().WithUrl("http://localhost:38308/signalr").Build();
			//connection.Closed += async (error) =>
			//{
			//	await connection.StartAsync();
			//};
			//connection.StartAsync();

			//connection.On<MessageModel>("BroadcastMessage", (msge) =>
			//{
			//	var newMessage = $"{msge.From}: {msge.Message}";
			//	Console.WriteLine(newMessage);
			//});

			//while (true)
			//{
			//	Console.WriteLine("Nhập nội dung: ");
			//	var cntext = Console.ReadLine();

			//	connection.InvokeAsync("BroadcastMessage", connection.ConnectionId, cntext);
			//}
		}
	}

	public class MessageModel
	{
		public string Timestamp { get; set; }
		public string From { get; set; }
		public string Code { get; set; }
		public string Message { get; set; }
	}
}
