using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TraCuu.GiamKichSan.Entities
{
	[Table("TraCuu_PersionCommunity")]
	public class PersionCommunityEntity
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(100)]
		[Required]
		public string Alias { get; set; }
		[MaxLength(200)]
		[Required]
		public string Name { get; set; }
		[MaxLength(22)]
		[Required]
		public string Birthday { get; set; }
		[MaxLength(500)]
		[Required]
		public string Address { get; set; }
		[MaxLength(300)]
		public string Image { get; set; }
		public int WorkCategoryID { get; set; }
		public bool IsShow { get; set; }
	}
}
