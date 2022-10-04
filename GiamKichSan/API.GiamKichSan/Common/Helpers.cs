using API.GiamKichSan.UploadFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.GiamKichSan.Common
{
	public class Helpers
	{
		public static string directoryRoot = Directory.GetCurrentDirectory();

		public static bool DirectoryExist(string directoryName)
		{
			return Directory.Exists(directoryName);
		}
		public static string[] GetFileInFolder(string directoryName, string extention)
		{
			return Directory.GetFiles(directoryName).Where(x => x.EndsWith(extention)).Select(x => x.Split('\\').LastOrDefault().Replace(extention, "")).ToArray();
		}

		public static string[] GetFolderInFolder(string directoryName)
		{
			return Directory.GetDirectories(directoryName).Select(x => x.Split('\\').LastOrDefault()).ToArray();
		}

		public static string CreateDirectory(string directoryParent, string directoryName)
		{
			var path = Path.Combine(directoryParent, directoryName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}
		public static bool WriteInFile(string fileName, string fileOut, string extention, Func<string, bool> validate, Func<String, string> correctText)
		{
			var pathFileRead = fileName + extention;
			var pathFileOut = fileOut + ".txt";
			var strBulder = new StringBuilder();

			var fileStream = File.OpenText(pathFileRead);

			while (!fileStream.EndOfStream)
			{
				var temp = fileStream.ReadLine();
				if (validate(temp))
				{
					strBulder.AppendLine(correctText(temp));
				}
			}
			fileStream.Close();
			File.WriteAllText(pathFileOut, strBulder.ToString());
			return true;
		}

		public static async Task<string> UploadFile(FTPModel fTPModel, IFormFile formFile, string directory)
		{
			string fileName = "";
			if (formFile.Length > 0)
			{
				var fTPUploadFile = new FTPUploadFile(fTPModel);
				var output = await fTPUploadFile.FileUpload(formFile.OpenReadStream(), formFile.FileName, directory);
				if (output.isValidate && Convert.ToBoolean(output.obj))
				{
					fileName = Path.Combine(directory, formFile.FileName);
				}
			}
			return fileName;
		}

		public static async Task<byte[]> DownLoadFile(FTPModel fTPModel, string fileName, string directory)
		{
			if (string.IsNullOrWhiteSpace(fileName)) return null;
			var fTPUploadFile = new FTPUploadFile(fTPModel);
			var output = await fTPUploadFile.FileStreamDownload(Path.Combine(directory, fileName));
			if (output.isValidate && output.arrObj != null)
			{
				return output.arrObj;
			}
			return null;
		}

		public static List<System.Reflection.PropertyInfo> GetProperties<T>(T obj)
		{
			return typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).ToList();
		}

		public static List<System.Reflection.PropertyInfo> GetPropertiesInsert<T>(T obj)
		{
			return GetProperties(obj).FindAll(x => x.Name != "IPEdit" && x.Name != "DateEdit" && x.Name != "ID");
		}

		public static List<System.Reflection.PropertyInfo> GetPropertiesUpdate<T>(T obj)
		{
			return GetProperties(obj).FindAll(x => x.Name != "IPCreate" && x.Name != "DateCreate");
		}

		public static T2 CopyToData<T1, T2>(T1 itemSource, T2 itemOut)
		{
			if (itemSource == null) return default(T2);
			// Display the Result
			foreach (var proT2 in GetProperties(itemOut))
			{
				foreach (var proT1 in GetProperties(itemSource))
				{
					if (proT2.Name == proT1.Name && proT1.GetValue(itemSource) != null)
					{
						proT2.SetValue(itemOut, proT1.GetValue(itemSource));
						break;
					}
				}
			}

			return itemOut;
		}

		public static void CopyToDataInsert<T1, T2>(T1 itemSource, ref T2 itemOut)
		{
			if (itemSource == null) return;
			// Display the Result
			foreach (var proT2 in GetPropertiesInsert(itemOut))
			{
				foreach (var proT1 in GetPropertiesInsert(itemSource))
				{
					if (proT2.Name == proT1.Name && proT1.GetValue(itemSource) != null)
					{
						proT2.SetValue(itemOut, proT1.GetValue(itemSource));
						break;
					}
				}
			}
		}
		public static void CopyToDataUpdate<T1, T2>(T1 itemSource, ref T2 itemOut)
		{
			if (itemSource == null) return;
			// Display the Result
			foreach (var proT2 in GetPropertiesUpdate(itemOut))
			{
				foreach (var proT1 in GetPropertiesUpdate(itemSource))
				{
					if (proT2.Name == proT1.Name && proT1.GetValue(itemSource) != null)
					{
						proT2.SetValue(itemOut, proT1.GetValue(itemSource));
						break;
					}
				}
			}
		}
	}
}
