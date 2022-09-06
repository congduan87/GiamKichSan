using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Data;

namespace Blog.GiamKichSan.Common
{
	public class CntGlobal
	{
		public static BlogDbContext blogDbContext { get; set; }
	}
}
