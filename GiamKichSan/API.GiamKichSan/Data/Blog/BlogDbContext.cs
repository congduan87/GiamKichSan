using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Data.Blog
{
	public class BlogDbContext:DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{

		}

		public DbSet<Entities.Blog.CategoryEntity> Blog_Categories { get; set; }
		public DbSet<Entities.Blog.PostDetailEntity> Blog_PostDetaiEntities { get; set; }
		public DbSet<Entities.Blog.PostEntity> Blog_PostEntities { get; set; }
		public DbSet<Entities.Blog.TagEntity> Blog_TagEntities { get; set; }
	}
}
