using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Blog
{
	[Table("Blog_Post")]
	public class PostEntity : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int IDCategory { get; set; }
		[MaxLength(500)]
		[Required]
		public string Title { get; set; }
		[MaxLength(4000)]
		[Required]
		public string Description { get; set; }
		[MaxLength(2000)]
		public string IDTags { get; set; }
		public int Status { get; set; }
	}
}
