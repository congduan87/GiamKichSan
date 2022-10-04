using API.GiamKichSan.Common;
using API.GiamKichSan.Data;
using API.GiamKichSan.Data.Search;
using API.GiamKichSan.Entities.Search;
using API.GiamKichSan.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.GiamKichSan.Services.Search
{
	public class CommunityServices : IData<CommunityModel, CommunityEntity>
	{
		private CommunityData communityData { get; set; }
		private CategoryServices categoryServices { get; set; }
		public CommunityServices()
		{
			communityData = new CommunityData();
			categoryServices = new CategoryServices();
		}

		public int Insert(CommunityModel item)
		{
			var temp = new CommunityEntity();
			Helpers.CopyToDataInsert(item, ref temp);
			temp.DateCreate = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return communityData.Insert(temp);
		}

		public bool Edit(CommunityModel item)
		{
			var temp = communityData.GetByID(item.ID);
			Helpers.CopyToDataUpdate(item, ref temp);
			temp.DateEdit = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return communityData.Edit(temp);
		}

		public bool Delete(int ID)
		{
			return communityData.Delete(ID);
		}

		public List<CommunityModel> GetAll(Func<CommunityEntity, bool> func = null)
		{
			var list = communityData.GetAll(func).Select(x => Helpers.CopyToData(x, new CommunityModel())).ToList();
			if(list != null)
			{
				var categories = categoryServices.GetAll(x=> list.Any(l=>l.CategoryID == x.ID));
				foreach (var item in list)
				{
					item.CategoryName = categories.FirstOrDefault(x=>x.ID == item.CategoryID)?.Name??"";
				}
			}
			return list;
		}

		public CommunityModel GetByID(int ID)
		{
			var item = Helpers.CopyToData(communityData.GetByID(ID), new CommunityModel());
			if(item != null && item.CategoryID > 0)
			{
				item.CategoryName = categoryServices.GetByID(item.CategoryID ?? 0).Name??"";
			}
			return item;
		}
	}
}
