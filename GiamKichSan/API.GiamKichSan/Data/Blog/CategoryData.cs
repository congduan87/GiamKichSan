﻿using API.GiamKichSan.Common;
using API.GiamKichSan.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Data.Blog
{
	public class CategoryData
	{
		public int Insert(CategoryEntity item)
		{
			CntGlobal.gKSDbContext.Blog_Categories.Add(item);
			CntGlobal.gKSDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(CategoryEntity item)
		{
			CntGlobal.gKSDbContext.Blog_Categories.Update(item);
			return CntGlobal.gKSDbContext.SaveChanges() > 0;
		}

		public bool Delete(int ID)
		{
			var item = this.GetByID(ID);
			if (item != null && item.ID > 0)
			{
				CntGlobal.gKSDbContext.Blog_Categories.Remove(item);
				return CntGlobal.gKSDbContext.SaveChanges() > 0;
			}
			else
			{
				return false;
			}
		}

		public List<CategoryEntity> GetAll(Func<CategoryEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.gKSDbContext.Blog_Categories.ToList();
			else
				return CntGlobal.gKSDbContext.Blog_Categories.Where(func).ToList();
		}
		public CategoryEntity GetByID(int ID)
		{
			return CntGlobal.gKSDbContext.Blog_Categories.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
