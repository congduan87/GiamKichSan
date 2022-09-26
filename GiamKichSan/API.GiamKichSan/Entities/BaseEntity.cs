using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Entities
{
	public class BaseEntity
	{
		[MaxLength(22)]
		public string DateCreate { get; set; }
		[MaxLength(26)]
		public string IPCreate { get; set; }
		[MaxLength(22)]
		public string DateEdit { get; set; }
		[MaxLength(26)]
		public string IPEdit { get; set; }
		[MaxLength(26)]
		public string Token { get; set; }
	}
}
