using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Common
{
	public class EnumType
	{
		public enum EnMediaType
		{
			[Description("Facebook")]
			Facebook = 1,
			[Description("Youtube")]
			Youtube = 2,
			[Description("Tiktok")]
			Tiktok = 3,
			[Description("Wikipedia")]
			Wikipedia = 4
		}
	}
}
