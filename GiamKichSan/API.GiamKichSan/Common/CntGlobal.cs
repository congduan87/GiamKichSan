using API.GiamKichSan.Data;

namespace API.GiamKichSan.Common
{
	public class CntGlobal
	{
		//File
		public const int MaxLengthUploadFile = 10240000;

		//DateTime
		public const string FormatDateTime = "yyyy-MM-dd HH:mm:ss:ff";
		public static GKSDbContext gKSDbContext { get; set; }
	}
}
