using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Blog
{
	[Table("Blog_Tag")]
	public class TagEntity : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(500)]
		[Required]
		public string Name { get; set; }
	}
}
