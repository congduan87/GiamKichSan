using API.GiamKichSan.Common;
using API.GiamKichSan.Data.Blog;
using API.GiamKichSan.Entities.Blog;
using API.GiamKichSan.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API.GiamKichSan.Param.Blog
{
	public class CategoryServices
	{
		private CategoryData categoryData { get; set; }
		public CategoryServices()
		{
			this.categoryData = new CategoryData();
		}
		public int Insert(CategoryInsertParam item)
		{
			var temp = new CategoryEntity();
			Helpers.CopyData(item, temp);
			temp.DateCreate = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return categoryData.Insert(temp);
		}
		public bool Edit(CategoryUpdateParam item)
		{
			var temp = categoryData.GetByID(item.ID);
			Helpers.CopyData(item, temp);
			temp.DateEdit = DateTime.Now.ToString(CntGlobal.FormatDateTime);
			return categoryData.Edit(temp);
		}
		public bool Delete(int ID)
		{
			return categoryData.Delete(ID);
		}
		public IEnumerable<CategoryModel> GetAll(string name)
		{
			IEnumerable<CategoryEntity> listData;
			if (string.IsNullOrWhiteSpace(name))
				listData = categoryData.GetAll();
			else
				listData = categoryData.GetAll(x => x.Name.Contains(name));

			if (listData != null)
			{
				List<CategoryModel> models = new List<CategoryModel>();
				foreach (var item in listData)
				{
					var temp = new CategoryModel();
					Helpers.CopyData(item, temp);
					models.Add(temp);
				}
				return models;
			}
			else
			{
				return null;
			}
		}
		public CategoryModel GetByID(int ID)
		{
			return categoryData.GetByID(ID) as CategoryModel;
		}
	}

	public class CategoryInsertParam
	{
		public int? IDParent { get; set; }
		[MaxLength(500)]
		public string Name { get; set; }
		[MaxLength(26)]
		public string IPCreate { get; set; }
	}
	public class CategoryUpdateParam
	{
		public int ID { get; set; } = 0;
		public int? IDParent { get; set; }
		[MaxLength(500)]
		public string Name { get; set; }
		[MaxLength(26)]
		public string IPEdit { get; set; }
	}


}
