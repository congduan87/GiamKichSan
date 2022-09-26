using Microsoft.EntityFrameworkCore;

namespace API.GiamKichSan.Data
{
	public class GKSDbContext :DbContext
	{
		public GKSDbContext (DbContextOptions<GKSDbContext > options) : base(options)
		{

		}

		//SEARCH
		public DbSet<Entities.Search.CategoryEntity> Search_Categories { get; set; }
		public DbSet<Entities.Search.CommunityMediaEntity> Search_CommunityMediaEntities { get; set; }
		public DbSet<Entities.Search.CommunityEntity> Search_CommunityEntities { get; set; }

		//BLOG
		public DbSet<Entities.Blog.CategoryEntity> Blog_Categories { get; set; }
		public DbSet<Entities.Blog.PostDetailEntity> Blog_PostDetaiEntities { get; set; }
		public DbSet<Entities.Blog.PostEntity> Blog_PostEntities { get; set; }
		public DbSet<Entities.Blog.TagEntity> Blog_TagEntities { get; set; }

	}
}
