using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Entities;

namespace Blog.GiamKichSan.Data
{
	public class BlogDbContext:DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{

		}
		public DbSet<TagEntity> Tags { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<PostEntity> Posts { get; set; }
		public DbSet<PostDetailEntity> PostDetails { get; set; }
		
	}
}
