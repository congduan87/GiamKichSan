using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Blog
{
	[Table("Blog_PostDetail")]
	public class PostDetailEntity : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int? IDParent { get; set; }
		[Required]
		public int IDPost { get; set; }
		[Required]
		[MaxLength(4000)]
		public string Description { get; set; }
		[MaxLength(10)]
		public string TagName { get; set; }
		public bool IsTagClose { get; set; }
		[MaxLength(200)]
		public string TagAttribute { get; set; }
	}
}
