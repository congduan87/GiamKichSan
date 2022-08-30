using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraCuu.GiamKichSan.Common;
using TraCuu.GiamKichSan.Data;
using TraCuu.GiamKichSan.Entities;
using TraCuu.GiamKichSan.Enum;
using TraCuu.GiamKichSan.Model;

namespace TraCuu.GiamKichSan.Services
{
	public class PersonCommunityServices
	{
		private static PersionCommunityData _persionCommunityData;
		private static PersionCommunityData persionCommunityData
		{
			get
			{
				if (_persionCommunityData == null)
				{
					_persionCommunityData = new PersionCommunityData();
				}
				return _persionCommunityData;
			}
		}
		private static PersionCommunityMediaData _persionCommunityMediaData;
		private static PersionCommunityMediaData persionCommunityMediaData
		{
			get
			{
				if (_persionCommunityMediaData == null)
				{
					_persionCommunityMediaData = new PersionCommunityMediaData();
				}
				return _persionCommunityMediaData;
			}
		}
		private static WorkCategoryData _workCategoryData;
		private static WorkCategoryData workCategoryData
		{
			get
			{
				if (_workCategoryData == null)
				{
					_workCategoryData = new WorkCategoryData();
				}
				return _workCategoryData;
			}
		}
		private PersionCommunityEntity ConvertTo(PersonCommunityModel item)
		{
			return item as PersionCommunityEntity;
		}
		private PersonCommunityModel ConvertTo(PersionCommunityEntity item)
		{
			return new PersonCommunityModel()
			{
				ID = item.ID,
				Address = item.Address,
				Alias = item.Alias,
				Birthday = item.Birthday,
				Image = item.Image,
				Name = item.Name,
				WorkCategoryID = item.WorkCategoryID,
				IsShow = item.IsShow,
				Facebook = "",
				Tiktok = "",
				Wikipedia = "",
				WorkCategoryName = "",
				Youtube = "",				
			};
		}
		private void ConvertTo(PersonCommunityModel item, WorkCategoryEntity workCate)
		{
			item.WorkCategoryName = workCate?.Name ?? "";
		}
		private void ConvertTo(PersonCommunityModel item, List<PersionCommunityMediaEntity> medias)
		{
			if (medias != null && medias.Count > 0)
			{
				foreach (var media in medias)
				{
					if (!string.IsNullOrWhiteSpace(media.Name) && media.MediaType == (int)EnMediaType.Facebook)
					{
						item.Facebook = media.Name;
					}
					if (!string.IsNullOrWhiteSpace(media.Name) && media.MediaType == (int)EnMediaType.Youtube)
					{
						item.Youtube = media.Name;
					}
					if (!string.IsNullOrWhiteSpace(media.Name) && media.MediaType == (int)EnMediaType.Tiktok)
					{
						item.Tiktok = media.Name;
					}
					if (!string.IsNullOrWhiteSpace(media.Name) && media.MediaType == (int)EnMediaType.Wikipedia)
					{
						item.Wikipedia = media.Name;
					}
				}
			}
		}

		private bool SaveMultiplePersionCommunityMedia(PersonCommunityModel item, int persionCommunityID)
		{
			PersionCommunityMediaEntity media = null;
			if (!string.IsNullOrWhiteSpace(item.Facebook))
			{
				media = new PersionCommunityMediaEntity() { Name = item.Facebook, PersionCommunityID = persionCommunityID, MediaType = (int)EnMediaType.Facebook };
				CntGlobal.traCuuDbContext.PersionCommunityMedias.Add(media);
			}
			if (!string.IsNullOrWhiteSpace(item.Youtube))
			{
				media = new PersionCommunityMediaEntity() { Name = item.Youtube, PersionCommunityID = persionCommunityID, MediaType = (int)EnMediaType.Youtube };
				CntGlobal.traCuuDbContext.PersionCommunityMedias.Add(media);
			}
			if (!string.IsNullOrWhiteSpace(item.Tiktok))
			{
				media = new PersionCommunityMediaEntity() { Name = item.Tiktok, PersionCommunityID = persionCommunityID, MediaType = (int)EnMediaType.Tiktok };
				CntGlobal.traCuuDbContext.PersionCommunityMedias.Add(media);
			}
			if (!string.IsNullOrWhiteSpace(item.Wikipedia))
			{
				media = new PersionCommunityMediaEntity() { Name = item.Wikipedia, PersionCommunityID = persionCommunityID, MediaType = (int)EnMediaType.Wikipedia };
				CntGlobal.traCuuDbContext.PersionCommunityMedias.Add(media);
			}

			return CntGlobal.traCuuDbContext.SaveChanges() >= 0;
		}
		public int Insert(PersonCommunityModel item)
		{
			PersionCommunityEntity pers = ConvertTo(item);
			CntGlobal.traCuuDbContext.PersionCommunities.Add(pers);
			if (CntGlobal.traCuuDbContext.SaveChanges() <= 0) return -1;
			if (!SaveMultiplePersionCommunityMedia(item, pers.ID)) return -1;
			return pers.ID;
		}

		public bool Edit(PersonCommunityModel item)
		{
			PersionCommunityEntity pers = ConvertTo(item);
			CntGlobal.traCuuDbContext.PersionCommunities.Update(pers);
			if (CntGlobal.traCuuDbContext.SaveChanges() <= 0) return false;

			var medias = persionCommunityMediaData.GetAll(x => x.PersionCommunityID == item.ID);
			if (medias != null && medias.Count > 0)
			{
				CntGlobal.traCuuDbContext.PersionCommunityMedias.RemoveRange(medias);
			}
			return SaveMultiplePersionCommunityMedia(item, item.ID);
		}

		public bool Delete(PersonCommunityModel item)
		{
			var medias = persionCommunityMediaData.GetAll(x => x.PersionCommunityID == item.ID);
			if (medias != null && medias.Count > 0)
			{
				CntGlobal.traCuuDbContext.PersionCommunityMedias.RemoveRange(medias);
			}
			CntGlobal.traCuuDbContext.PersionCommunities.Remove(ConvertTo(item));
			return CntGlobal.traCuuDbContext.SaveChanges() > 0;
		}

		public List<PersonCommunityModel> GetAll(Func<PersionCommunityEntity, bool> func = null)
		{
			List<PersonCommunityModel> result = new List<PersonCommunityModel>();
			var pesonsC = persionCommunityData.GetAll(func);
			if (pesonsC != null && pesonsC.Count > 0)
			{
				var medias = persionCommunityMediaData.GetAll(x => pesonsC.Any(y => y.ID.Equals(x.PersionCommunityID)));
				var workCates = workCategoryData.GetAll(x => pesonsC.Any(y => y.WorkCategoryID.Equals(x.ID)));
				foreach (var pesonC in pesonsC)
				{
					var item = ConvertTo(pesonC);
					ConvertTo(item, medias.FindAll(x => x.PersionCommunityID.Equals(item.ID)));
					ConvertTo(item, workCates.Find(x => x.ID.Equals(item.WorkCategoryID)));
					result.Add(item);
				}
			}
			return result;
		}
		public PersonCommunityModel GetByID(int ID)
		{
			var pesonsC = CntGlobal.traCuuDbContext.PersionCommunities.FirstOrDefault(x => x.ID.Equals(ID));
			if (pesonsC == null) return null;
			var medias = persionCommunityMediaData.GetAll(x => x.PersionCommunityID.Equals(pesonsC.ID));
			var workCate = workCategoryData.GetByID(pesonsC.WorkCategoryID);
			PersonCommunityModel item = ConvertTo(pesonsC);
			ConvertTo(item, medias);
			ConvertTo(item, workCate);
			return item;
		}

	}
}
