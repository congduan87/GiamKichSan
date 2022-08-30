using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TraCuu.GiamKichSan.Entities
{
	[Table("TraCuu_WorkCategory")]
	public class WorkCategoryEntity
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(500)]
		[Required]
		public string Name { get; set; }
	}
}
