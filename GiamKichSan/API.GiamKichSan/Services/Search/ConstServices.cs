using API.GiamKichSan.Common;
using API.GiamKichSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Services.Search
{
	public class ConstServices
	{
		public IEnumerable<ConstModel> GetAllMediaType()
		{
			var type = typeof(EnumType.EnMediaType);
			var values = Enum.GetValues(type).Cast<EnumType.EnMediaType>().Select(x => new ConstModel() { ID = (int)x, Name = x.ToString() }).ToList();
			for (int index = 0; index < values.Count; index++)
			{
				var field = type.GetField(values[index].Name);
				var descriptions = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
				foreach (System.ComponentModel.DescriptionAttribute description in descriptions)
				{
					values[index].Description = description.Description;
					break;
				}
			}
			return values;
		}

		public ConstModel GetMediaType(int iD)
		{
			var type = typeof(EnumType.EnMediaType);
			var values = Enum.GetValues(type).Cast<EnumType.EnMediaType>().Select(x => new ConstModel() { ID = (int)x, Name = x.ToString() }).ToList();
			for (int index = 0; index < values.Count; index++)
			{
				if (iD == values[index].ID)
				{
					var field = type.GetField(values[index].Name);
					var descriptions = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
					foreach (System.ComponentModel.DescriptionAttribute description in descriptions)
					{
						values[index].Description = description.Description;
						return values[index];
					}
				}

			}
			return new ConstModel();
		}
	}
}
