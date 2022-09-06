﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.GiamKichSan.Common;
using Blog.GiamKichSan.Data;
using Blog.GiamKichSan.Entities;
using Blog.GiamKichSan.Enum;
using Blog.GiamKichSan.Model;

namespace Blog.GiamKichSan.Services
{
	public class PostServices
	{
		private static PostData _postData;
		private static PostDetailData _postDetailData;
		private static CategoryData _categoryData;
		private static TagData _tagData;

		private static PostData postData
		{
			get
			{
				if (_postData == null)
				{
					_postData = new PostData();
				}
				return _postData;
			}
		}
		private static PostDetailData postDetailData
		{
			get
			{
				if (_postDetailData == null)
				{
					_postDetailData = new PostDetailData();
				}
				return _postDetailData;
			}
		}
		private static CategoryData categoryData
		{
			get
			{
				if (_categoryData == null)
				{
					_categoryData = new CategoryData();
				}
				return _categoryData;
			}
		}
		private static TagData tagData
		{
			get
			{
				if (_tagData == null)
				{
					_tagData = new TagData();
				}
				return _tagData;
			}
		}
		public int Insert(PostModel item)
		{
			var IDPost = postData.Insert(item);
			int IDPostDetail = 0;
			if (IDPost <= 0) return -1;
			foreach (var postDetail in item.PostDetails)
			{
				IDPostDetail = postDetailData.Insert(postDetail);
				if (IDPostDetail <= 0) return -1;
			}
			return IDPost;
		}

		public bool Edit(PostModel item)
		{
			if (!postData.Edit(item)) return false;

			var postDetails = postDetailData.GetAll(x => x.IDPost == item.ID);
			if (postDetails != null && postDetails.Count > 0)
			{
				foreach (var postDetail in postDetails)
				{
					postDetailData.Delete(postDetail);
				}
			}
			foreach (var postDetail in item.PostDetails)
			{
				if (postDetailData.Insert(postDetail) <= 0) return false;
			}
			return true;
		}

		public bool Delete(PostModel item)
		{
			var postDetails = postDetailData.GetAll(x => x.IDPost == item.ID);
			if (postDetails != null && postDetails.Count > 0)
			{
				foreach (var postDetail in postDetails)
				{
					postDetailData.Delete(postDetail);
				}
			}
			if (!postData.Delete(item)) return false;
			return true;
		}

		public List<PostModel> GetAll(Func<PostEntity, bool> func = null)
		{
			List<PostModel> result = new List<PostModel>();
			var posts = postData.GetAll(func);
			if (posts != null && posts.Count > 0)
			{
				var postsDetails = postDetailData.GetAll(x => posts.Any(y => y.ID.Equals(x.IDPost)));
				var categories = categoryData.GetAll(x => posts.Any(y => y.IDCategory.Equals(x.ID)));
				var tags = tagData.GetAll(x => posts.Any(y => ("," + y.IDTag + ",").Contains("," + x.ID + ",")));
				foreach (var post in posts)
				{
					var postDetail = postsDetails.FindAll(x => x.IDPost == post.ID);
					var category = categories.Find(x => x.ID == post.IDCategory);
					var tag = tags.FindAll(x => ("," + post.IDTag + ",").Contains("," + x.ID + ","));
					result.Add(RenderPostModel(post, postDetail, category, tag));
				}
			}
			return result;
		}
		public PostModel GetByID(int ID)
		{
			var post = postData.GetByID(ID);
			if (post == null) return null;
			var postDetail = postDetailData.GetAll(x => x.IDPost.Equals(post.ID));
			var category = categoryData.GetByID(post.IDCategory);
			var tag = tagData.GetAll(x => ("," + post.IDTag + ",").Contains("," + x.ID + ","));
			return RenderPostModel(post, postDetail, category, tag);
		}
		private PostModel RenderPostModel(PostEntity post, List<PostDetailEntity> postDetail, CategoryEntity category, List<TagEntity> tag)
		{
			PostModel result = post as PostModel;
			result.CategoryName = category.Name;
			result.TagName = string.Join(", ", tag.Select(x => x.Name).ToArray());
			result.PostDetails = postDetail;
			return result;
		}

	}
}