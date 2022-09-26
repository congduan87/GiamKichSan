using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Blog
{
	[Table("Blog_Category")]
	public class CategoryEntity : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		public int? IDParent { get; set; }
		[MaxLength(500)]
		[Required]
		public string Name { get; set; }
	}
}
