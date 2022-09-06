using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Common;
using Blog.GiamKichSan.Entities;

namespace Blog.GiamKichSan.Data
{
	public class PostData
	{
		public int Insert(PostEntity item)
		{
			CntGlobal.blogDbContext.Posts.Add(item);
			CntGlobal.blogDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(PostEntity item)
		{
			CntGlobal.blogDbContext.Posts.Update(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public bool Delete(PostEntity item)
		{
			CntGlobal.blogDbContext.Posts.Remove(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public List<PostEntity> GetAll(Func<PostEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.blogDbContext.Posts.ToList();
			else
				return CntGlobal.blogDbContext.Posts.Where(func).ToList();
		}
		public PostEntity GetByID(int ID)
		{
			return CntGlobal.blogDbContext.Posts.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
