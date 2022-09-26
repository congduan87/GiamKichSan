using Microsoft.EntityFrameworkCore;

namespace API.GiamKichSan.Data
{
	public class SearchDbContext : DbContext
	{
		public SearchDbContext(DbContextOptions<SearchDbContext> options) : base(options)
		{

		}

		public DbSet<Entities.Search.CategoryEntity> Search_Categories { get; set; }
		public DbSet<Entities.Search.CommunityMediaEntity> Search_CommunityMediaEntities { get; set; }
		public DbSet<Entities.Search.CommunityEntity> Search_CommunityEntities { get; set; }
	}
}
