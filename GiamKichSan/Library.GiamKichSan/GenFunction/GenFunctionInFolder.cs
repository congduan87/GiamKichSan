using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GiamKichSan.GenFunction
{
	public interface IGenFunctionInFolder
	{
		void Generate(string folderName);
	}
	public class GenFunctionInFolder : IGenFunctionInFolder
	{
		private string extendtion = ".frm";
		private string term = "Sub";
		public void Generate(string folderName)
		{
			if (!Helpers.DirectoryExist(folderName)) return;
			string directoryRoot = Helpers.CreateDirectory(Helpers.directoryRoot, "FunctionInFolder" + DateTime.Now.ToString("yyMMddHHmmss"));
			GenerateSubFolder(folderName, directoryRoot);
		}
		private void GenerateSubFolder(string directoryPath, string directoryRoot)
		{
			foreach (var itemFolder in Helpers.GetFolderInFolder(directoryPath))
			{
				GenerateSubFolder(Path.Combine(directoryPath, itemFolder), Helpers.CreateDirectory(directoryRoot, itemFolder));
			}

			foreach (var itemFile in Helpers.GetFileInFolder(directoryPath, extendtion))
			{
				Helpers.WriteInFile(Path.Combine(directoryPath, itemFile), Path.Combine(directoryRoot, itemFile), extendtion, IsFunctionInText, GetFunctionNameInText);
			}
		}

		private bool IsFunctionInText(string text)
		{
			return text.Contains(term + " ") && text.TrimEnd().LastOrDefault().Equals(')');
		}

		private string GetFunctionNameInText(string text)
		{
			return text.Substring(text.IndexOf(term) + term.Length).Trim();
		}
	}
}
