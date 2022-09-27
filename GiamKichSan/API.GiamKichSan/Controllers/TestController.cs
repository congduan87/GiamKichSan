﻿using API.GiamKichSan.Common;
using API.GiamKichSan.SignalR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Controllers
{
	[ApiController]
	[Route("Blog/[controller]")]
	[EnableCors("AllowOrigin")]
	public class TestController : ControllerBase
	{
		private IHubContext<SignalrHub, IHubClient> _signalrHub;
		private IConfiguration _config;
		public TestController(IHubContext<SignalrHub, IHubClient> signalrHub, IConfiguration config)
		{
			_signalrHub = signalrHub;
			this._config = config;
		}

		//[HttpPost]
		//public async Task<string> Post([FromBody] MessageModel msg)
		//{
		//	var retMessage = string.Empty;
		//	try
		//	{
		//		msg.Timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff");
		//		await _signalrHub.Clients.All.BroadcastMessage(msg);
		//		retMessage = "Success";
		//	}
		//	catch (Exception e)
		//	{
		//		retMessage = e.ToString();
		//	}
		//	return retMessage;
		//}

		[HttpPost]
		public async Task<string> Post([FromBody] UploadFileAPI upLoadFile)
		{
			var retMessage = await Helpers.UploadFile(_config, upLoadFile.formFile, "DuanVC");			
			return retMessage;
		}

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}

	public class UploadFileAPI
	{
		public IFormFile formFile { get; set; }
	}

	public class WeatherForecast
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}
}
