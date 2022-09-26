using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Search
{
	[Table("Search_CommunityEntity")]
	public class CommunityEntity : BaseEntity
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
		public int? CategoryID { get; set; }
		public int? Status { get; set; }
	}
}
