using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Entities;

namespace TraCuu.GiamKichSan.Data
{
	public class TraCuuDbContext:DbContext
	{
		public TraCuuDbContext(DbContextOptions<TraCuuDbContext> options) : base(options)
		{

		}
		public DbSet<PersionCommunityMediaEntity> PersionCommunityMedias { get; set; }
		public DbSet<PersionCommunityEntity> PersionCommunities { get; set; }
		public DbSet<WorkCategoryEntity> WorkCategories { get; set; }
	}
}
