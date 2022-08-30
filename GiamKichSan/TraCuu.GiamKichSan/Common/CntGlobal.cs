using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Data;

namespace TraCuu.GiamKichSan.Common
{
	public class CntGlobal
	{
		private const string _TYPEPROJECT = "TraCuu";
		public static TraCuuDbContext traCuuDbContext { get; set; }
	}
}
