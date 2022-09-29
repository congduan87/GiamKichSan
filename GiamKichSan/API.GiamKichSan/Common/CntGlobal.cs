using API.GiamKichSan.Data;

namespace API.GiamKichSan.Common
{
	public class CntGlobal
	{
		public const int MaxLengthUploadFile = 10240000;
		public static GKSDbContext  gKSDbContext { get; set; }
	}
}
