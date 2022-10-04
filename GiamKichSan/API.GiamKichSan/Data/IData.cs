using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Data
{
	public interface IData<T, TM>
	{
		int Insert(T item);
		bool Edit(T item);
		bool Delete(int ID);
		List<T> GetAll(Func<TM, bool> func = null);
		T GetByID(int ID);
	}
}
