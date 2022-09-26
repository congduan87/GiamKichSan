using API.GiamKichSan.Common;
using API.GiamKichSan.Entities.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Data.Search
{
	public class CategoryData
	{
		public int Insert(CategoryEntity item)
		{
			CntGlobal.gKSDbContext.Search_Categories.Add(item);
			CntGlobal.gKSDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(CategoryEntity item)
		{
			CntGlobal.gKSDbContext.Search_Categories.Update(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public bool Delete(CategoryEntity item)
		{
			CntGlobal.gKSDbContext.Search_Categories.Remove(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public List<CategoryEntity> GetAll(Func<CategoryEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.gKSDbContext.Search_Categories.ToList();
			else
				return CntGlobal.gKSDbContext.Search_Categories.Where(func).ToList();
		}
		public CategoryEntity GetByID(int ID)
		{
			return CntGlobal.gKSDbContext.Search_Categories.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
