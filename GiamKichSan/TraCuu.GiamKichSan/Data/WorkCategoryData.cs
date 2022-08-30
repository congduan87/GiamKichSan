using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Common;
using TraCuu.GiamKichSan.Entities;

namespace TraCuu.GiamKichSan.Data
{
	public class WorkCategoryData
	{
		public int Insert(WorkCategoryEntity item)
		{
			CntGlobal.traCuuDbContext.WorkCategories.Add(item);
			CntGlobal.traCuuDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(WorkCategoryEntity item)
		{
			CntGlobal.traCuuDbContext.WorkCategories.Update(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public bool Delete(WorkCategoryEntity item)
		{
			CntGlobal.traCuuDbContext.WorkCategories.Remove(item);
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public List<WorkCategoryEntity> GetAll(Func<WorkCategoryEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.traCuuDbContext.WorkCategories.ToList();
			else
				return CntGlobal.traCuuDbContext.WorkCategories.Where(func).ToList();
		}
		public WorkCategoryEntity GetByID(int ID)
		{
			return CntGlobal.traCuuDbContext.WorkCategories.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
