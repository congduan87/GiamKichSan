using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TraCuu.GiamKichSan.Common
{
	public class Helpers
	{
		private const string IMAGE_ROOT = "images";
		public static string GetDirectoryWWWRoot()
		{
			return Path.GetFullPath("wwwroot\\" + IMAGE_ROOT);
		}
		private static string GetDirectory(string directory = "")
		{
			var pathCurrent = GetDirectoryWWWRoot();
			var path = directory.Trim().Replace("/", "\\");
			var pathArray = path.Split('\\');
			foreach (var item in pathArray)
			{
				if (item.Trim() != "")
				{
					pathCurrent = Path.Combine(pathCurrent, item.Trim());
					if (!Directory.Exists(pathCurrent))
					{
						Directory.CreateDirectory(pathCurrent);
					}
				}
			}
			return pathCurrent;
		}
		private static string GetNewFileName(Microsoft.AspNetCore.Http.IFormFile file)
		{
			var fileName = "";
			if (file == null)
				return fileName;
			else
				return Path.GetRandomFileName() + Path.GetExtension(file.FileName);
		}
		private static bool UploadFile(Microsoft.AspNetCore.Http.IFormFile fileUpload, string filePath)
		{
			var res = false;
			if (fileUpload.Length > 0)
			{
				using (var stream = System.IO.File.Create(filePath))
				{
					fileUpload.CopyTo(stream);
					res = true;
				}
			}
			return res;
		}
		public static string[] UploadFiles(Microsoft.AspNetCore.Http.IFormFile[] fileUploads, string directory)
		{
			var pathCurrent = GetDirectory(directory);
			string[] pathImage = new string[] { };
			if (fileUploads != null && fileUploads.Length > 0)
			{
				pathImage = new string[fileUploads.Length];
				for (int index = 0; index < fileUploads.Length; index++)
				{
					pathImage[index] = "";
					var newFileName = GetNewFileName(fileUploads[index]);
					if (newFileName == "") continue;
					var res = UploadFile(fileUploads[index], Path.Combine(pathCurrent, newFileName));
					if (res)
					{
						pathImage[index] = Path.Combine("\\", IMAGE_ROOT + (string.IsNullOrWhiteSpace(directory) ? "" : "\\" + directory.Trim()), newFileName);
					}
				}
			}
			return pathImage;
		}
	}
}
