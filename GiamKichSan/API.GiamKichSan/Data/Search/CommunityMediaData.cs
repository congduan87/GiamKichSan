using API.GiamKichSan.Common;
using API.GiamKichSan.Entities.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Data.Search
{
	public class CommunityMediaData
	{
		public int Insert(CommunityMediaEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityMediaEntities.Add(item);
			CntGlobal.gKSDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(CommunityMediaEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityMediaEntities.Update(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public bool Delete(CommunityMediaEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityMediaEntities.Remove(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public List<CommunityMediaEntity> GetAll(Func<CommunityMediaEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.gKSDbContext.Search_CommunityMediaEntities.ToList();
			else
				return CntGlobal.gKSDbContext.Search_CommunityMediaEntities.Where(func).ToList();
		}
		public CommunityMediaEntity GetByID(int ID)
		{
			return CntGlobal.gKSDbContext.Search_CommunityMediaEntities.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
