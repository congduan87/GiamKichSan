using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Common;
using TraCuu.GiamKichSan.Entities;

namespace TraCuu.GiamKichSan.Data
{
	public class PersionCommunityData
	{
		public int Insert(PersionCommunityEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunities.Add(item);
			CntGlobal.traCuuDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(PersionCommunityEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunities.Update(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public bool Delete(PersionCommunityEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunities.Remove(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public List<PersionCommunityEntity> GetAll(Func<PersionCommunityEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.traCuuDbContext.PersionCommunities.ToList();
			else
				return CntGlobal.traCuuDbContext.PersionCommunities.Where(func).ToList();
		}
		public PersionCommunityEntity GetByID(int ID)
		{
			return CntGlobal.traCuuDbContext.PersionCommunities.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
