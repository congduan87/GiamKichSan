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
	public class CommunityMediaServices : IData<CommunityMediaModel, CommunityMediaEntity>
	{
		private CommunityMediaData communityMediaData { get; set; }
		private ConstServices constServices { get; set; }
		public CommunityMediaServices()
		{
			communityMediaData = new CommunityMediaData();
			constServices = new ConstServices();
		}
		public bool Delete(int ID)
		{
			return communityMediaData.Delete(ID);
		}

		public bool Edit(CommunityMediaModel item)
		{
			var temp = communityMediaData.GetByID(item.ID);
			Helpers.CopyToDataUpdate(item, ref temp);
			temp.DateEdit = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return communityMediaData.Edit(temp);
		}

		public List<CommunityMediaModel> GetAll(Func<CommunityMediaEntity, bool> func = null)
		{
			var list = communityMediaData.GetAll(func).Select(x => Helpers.CopyToData(x, new CommunityMediaModel())).ToList();
			var constService = constServices.GetAllMediaType();
			foreach (var item in list)
			{
				item.MediaTypeName = constService.FirstOrDefault(x => x.ID == item.MediaType)?.Description??"";
			}
			return list;
		}

		public CommunityMediaModel GetByID(int ID)
		{
			var item = Helpers.CopyToData(communityMediaData.GetByID(ID), new CommunityMediaModel());
			var constService = constServices.GetMediaType(item.MediaType);
			item.MediaTypeName = constService?.Description??"";
			return item;
		}

		public int Insert(CommunityMediaModel item)
		{
			var temp = new CommunityMediaEntity();
			Helpers.CopyToDataInsert(item, ref temp);
			temp.DateCreate = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return communityMediaData.Insert(temp);
		}
	}
}
