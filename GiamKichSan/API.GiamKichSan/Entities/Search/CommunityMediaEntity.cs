using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.GiamKichSan.Entities.Search
{
	[Table("Search_CommunityMediaEntity")]
	public class CommunityMediaEntity : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int MediaType { get; set; }
		[Required]
		public int CommunityID { get; set; }
		[Required]
		[MaxLength(500)]
		public string Name { get; set; }
	}
}
