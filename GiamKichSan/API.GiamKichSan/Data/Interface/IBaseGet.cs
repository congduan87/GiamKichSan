using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan.Data.Interface
{
	public interface IBaseGet<T>
	{
		List<T> GetAll(Func<T, bool> func = null);
		T GetByID(int ID);
	}
}
