using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Data.Interface
{
	public interface IBaseUpdate<T>
	{
		int Insert(T item);
		bool Edit(T item);
		bool Delete(T item);
	}
}
