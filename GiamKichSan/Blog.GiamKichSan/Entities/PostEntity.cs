using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.GiamKichSan.Entities
{
	[Table("Blog_Post")]
	public class PostEntity
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(500)]
		[Required]
		public string Title { get; set; }
		[MaxLength(2000)]
		[Required]
		public string Description { get; set; }
		[Required]
		public int IDCategory { get; set; }
		[Required]
		public string IDTag { get; set; }
		public bool IsShow { get; set; }
	}
}
