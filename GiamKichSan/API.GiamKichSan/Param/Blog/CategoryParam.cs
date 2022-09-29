using API.GiamKichSan.Common;
using API.GiamKichSan.Entities.Blog;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.GiamKichSan.Param.Blog
{
	public class CategoryParam
	{
		public int ID { get; set; } = 0;
		public int? IDParent { get; set; }
		[MaxLength(500)]
		public string Name { get; set; } = "";
	}

	public class CategoryTerm
	{
		public int ID { get; set; } = 0;
		public int? IDParent { get; set; }
		[MaxLength(500)]
		public string Name { get; set; } = "";
	}
}
