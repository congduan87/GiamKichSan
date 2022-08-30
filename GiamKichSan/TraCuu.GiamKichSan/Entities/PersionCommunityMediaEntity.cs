using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraCuu.GiamKichSan.Entities
{
	[Table("TraCuu_PersionCommunityMedia")]
	public class PersionCommunityMediaEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int MediaType { get; set; }
		[Required]
		public int PersionCommunityID { get; set; }
		[Required]
		[MaxLength(500)]
		public string Name { get; set; }
	}
}
