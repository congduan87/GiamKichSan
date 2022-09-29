using API.GiamKichSan.Entities.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiamKichSan.Models.Search
{
	public class CommunityModel: CommunityEntity
	{
		[NotMapped]
		public string CategoryName { get; set; }
		[NotMapped]
		public string Facebook { get; set; }
		[NotMapped]
		public string Youtube { get; set; }
		[NotMapped]
		public string Tiktok { get; set; }
		[NotMapped]
		public string Wikipedia { get; set; }
	}
}
