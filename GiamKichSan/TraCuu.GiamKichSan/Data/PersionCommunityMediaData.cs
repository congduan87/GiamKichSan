using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Common;
using TraCuu.GiamKichSan.Entities;

namespace TraCuu.GiamKichSan.Data
{
	public class PersionCommunityMediaData
	{
		public int Insert(PersionCommunityMediaEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunityMedias.Add(item);
			CntGlobal.traCuuDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(PersionCommunityMediaEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunityMedias.Update(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public bool Delete(PersionCommunityMediaEntity item)
		{
			CntGlobal.traCuuDbContext.PersionCommunityMedias.Remove(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public List<PersionCommunityMediaEntity> GetAll(Func<PersionCommunityMediaEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.traCuuDbContext.PersionCommunityMedias.ToList();
			else
				return CntGlobal.traCuuDbContext.PersionCommunityMedias.Where(func).ToList();
		}
		public PersionCommunityMediaEntity GetByID(int ID)
		{
			return CntGlobal.traCuuDbContext.PersionCommunityMedias.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
