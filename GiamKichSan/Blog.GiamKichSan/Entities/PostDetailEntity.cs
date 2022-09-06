using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.GiamKichSan.Entities
{
	[Table("Blog_PostDetail")]
	public class PostDetailEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int IDPost { get; set; }
		[Required]
		[MaxLength(4000)]
		public string Description { get; set; }		
	}
}
