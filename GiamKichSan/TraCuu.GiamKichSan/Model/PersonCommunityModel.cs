using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraCuu.GiamKichSan.Model
{
	public class PersonCommunityModel: PersionCommunityEntity
	{
		[NotMapped]
		public string WorkCategoryName { get; set; }
		[NotMapped]
		public string Facebook { get; set; }
		[NotMapped]
		public string Youtube { get; set; }
		[NotMapped]
		public string Tiktok { get; set; }
		[NotMapped]
		public string Wikipedia { get; set; }
	}
}
