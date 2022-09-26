using API.GiamKichSan.Common;
using API.GiamKichSan.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Data
{
	public class BaseData<T> : IBaseGet<T>, IBaseUpdate<T>
	{
		public List<T> GetAll(Func<T, bool> func = null)
		{
			return null;
		}
		public T GetByID(int ID)
		{
			return default(T);
		}

		public int Insert(T item)
		{
			return 0;
		}
		public bool Delete(T item)
		{
			return false;
		}

		public bool Edit(T item)
		{
			return false;
		}
	}
}
