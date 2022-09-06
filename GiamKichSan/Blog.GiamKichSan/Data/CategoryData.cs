using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Common;
using Blog.GiamKichSan.Entities;

namespace Blog.GiamKichSan.Data
{
	public class CategoryData
	{
		public int Insert(CategoryEntity item)
		{
			CntGlobal.blogDbContext.Categories.Add(item);
			CntGlobal.blogDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(CategoryEntity item)
		{
			CntGlobal.blogDbContext.Categories.Update(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public bool Delete(CategoryEntity item)
		{
			CntGlobal.blogDbContext.Categories.Remove(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public List<CategoryEntity> GetAll(Func<CategoryEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.blogDbContext.Categories.ToList();
			else
				return CntGlobal.blogDbContext.Categories.Where(func).ToList();
		}
		public CategoryEntity GetByID(int ID)
		{
			return CntGlobal.blogDbContext.Categories.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
