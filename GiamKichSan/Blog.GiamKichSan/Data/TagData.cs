using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Common;
using Blog.GiamKichSan.Entities;

namespace Blog.GiamKichSan.Data
{
	public class TagData
	{
		public int Insert(TagEntity item)
		{
			CntGlobal.blogDbContext.Tags.Add(item);
			CntGlobal.blogDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(TagEntity item)
		{
			CntGlobal.blogDbContext.Tags.Update(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public bool Delete(TagEntity item)
		{
			CntGlobal.blogDbContext.Tags.Remove(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public List<TagEntity> GetAll(Func<TagEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.blogDbContext.Tags.ToList();
			else
				return CntGlobal.blogDbContext.Tags.Where(func).ToList();
		}
		public TagEntity GetByID(int ID)
		{
			return CntGlobal.blogDbContext.Tags.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
