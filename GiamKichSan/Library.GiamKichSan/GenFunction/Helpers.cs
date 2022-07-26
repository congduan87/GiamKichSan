﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GiamKichSan.GenFunction
{
	public class Helpers
	{
		public static string[] terms = new string[] { "Sub" };
		public static string directoryRoot = Directory.GetCurrentDirectory();

		public static bool DirectoryExist(string directoryName)
		{
			return Directory.Exists(directoryName);
		}
		public static string[] GetFileInFolder(string directoryName, string extention)
		{
			return Directory.GetFiles(directoryName).Where(x=>x.EndsWith(extention)).Select(x => x.Split('\\').LastOrDefault().Replace(extention, "")).ToArray();
		}

		public static string[] GetFolderInFolder(string directoryName)
		{
			return Directory.GetDirectories(directoryName).Select(x=>x.Split('\\').LastOrDefault()).ToArray();
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
	}
}
