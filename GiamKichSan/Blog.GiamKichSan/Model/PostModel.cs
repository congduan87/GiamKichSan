using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.GiamKichSan.Model
{
	public class PostModel : PostEntity
	{
		[NotMapped]
		public string CategoryName { get; set; }
		[NotMapped]
		public string TagName { get; set; }
		[NotMapped]
		public List<PostDetailEntity> PostDetails { get; set; } = new List<PostDetailEntity>();
		[NotMapped]
		public string PostDetailsDescription { get; set; }

		public PostModel() : base()
		{
			this.CategoryName = "";
			this.TagName = "";
			this.PostDetails = new List<PostDetailEntity>();
			this.PostDetailsDescription = "";
		}

		public PostModel(PostEntity postEntity)
		{
			this.ID = postEntity.ID;
			this.Title = postEntity.Title;
			this.Description = postEntity.Description;
			this.IDCategory = postEntity.IDCategory;
			this.IDTag = postEntity.IDTag;
			this.IsShow = postEntity.IsShow;
		}
	}
}
