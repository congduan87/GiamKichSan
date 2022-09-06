using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Common;
using Blog.GiamKichSan.Entities;

namespace Blog.GiamKichSan.Data
{
	public class PostDetailData
	{
		public int Insert(PostDetailEntity item)
		{
			CntGlobal.blogDbContext.PostDetails.Add(item);
			CntGlobal.blogDbContext.SaveChanges();
			return item.ID;
		}

		public bool Edit(PostDetailEntity item)
		{
			CntGlobal.blogDbContext.PostDetails.Update(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public bool Delete(PostDetailEntity item)
		{
			CntGlobal.blogDbContext.PostDetails.Remove(item);
			return CntGlobal.blogDbContext.SaveChanges() > 0;
		}

		public List<PostDetailEntity> GetAll(Func<PostDetailEntity, bool> func = null)
		{
			if (func == null)
				return CntGlobal.blogDbContext.PostDetails.ToList();
			else
				return CntGlobal.blogDbContext.PostDetails.Where(func).ToList();
		}
		public PostDetailEntity GetByID(int ID)
		{
			return CntGlobal.blogDbContext.PostDetails.FirstOrDefault(x => x.ID.Equals(ID));
		}
	}
}
