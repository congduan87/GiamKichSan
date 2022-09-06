using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.GiamKichSan.Entities
{
	[Table("Blog_Category")]
	public class CategoryEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int IDParent { get; set; }
		[MaxLength(500)]
		[Required]
		public string Name { get; set; }
	}
}
