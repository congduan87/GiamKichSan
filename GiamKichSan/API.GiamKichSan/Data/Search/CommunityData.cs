using API.GiamKichSan.Common;
using API.GiamKichSan.Entities.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Data.Search
{
	public class CommunityData
	{
		public int Insert(CommunityEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityEntities.Add(item);
			CntGlobal.gKSDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(CommunityEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityEntities.Update(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public bool Delete(CommunityEntity item)
		{
			CntGlobal.gKSDbContext.Search_CommunityEntities.Remove(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public List<CommunityEntity> GetAll(Func<CommunityEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.gKSDbContext.Search_CommunityEntities.ToList();
			else
				return CntGlobal.gKSDbContext.Search_CommunityEntities.Where(func).ToList();
		}
		public CommunityEntity GetByID(int ID)
		{
			return CntGlobal.gKSDbContext.Search_CommunityEntities.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
