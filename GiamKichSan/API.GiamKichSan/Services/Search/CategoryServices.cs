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
	public class CategoryServices : IData<CategoryModel, CategoryEntity>
	{
		private CategoryData categoryData { get; set; }
		public CategoryServices()
		{
			this.categoryData = new CategoryData();
		}
		public int Insert(CategoryModel item)
		{
			var temp = new CategoryEntity();
			Helpers.CopyToDataInsert(item, ref temp);
			temp.DateCreate = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return categoryData.Insert(temp);
		}

		public bool Edit(CategoryModel item)
		{
			var temp = categoryData.GetByID(item.ID);
			Helpers.CopyToDataUpdate(item, ref temp);
			temp.DateEdit = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return categoryData.Edit(temp);
		}

		public bool Delete(int ID)
		{
			return categoryData.Delete(ID);
		}

		public List<CategoryModel> GetAll(Func<CategoryEntity, bool> func = null)
		{
			return categoryData.GetAll(func).Select(x => Helpers.CopyToData(x, new CategoryModel())).ToList();
		}

		public CategoryModel GetByID(int ID)
		{
			return Helpers.CopyToData(categoryData.GetByID(ID), new CategoryModel());
		}
	}
}
