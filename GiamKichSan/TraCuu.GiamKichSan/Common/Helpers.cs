using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TraCuu.GiamKichSan.Common
{
	public class Helpers
	{
		public static string[] UploadFile(Microsoft.AspNetCore.Http.IFormFile[] FileUploads)
		{
            string[] pathImage = new string[] { };
            if (FileUploads != null && FileUploads.Length > 0)
			{
                pathImage = new string[FileUploads.Length];
                var index = 0;
                foreach (var formFile in FileUploads)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(@"\images\Author", Path.GetRandomFileName() + Path.GetExtension(formFile.FileName));
                        var filePathFull = Path.GetFullPath("wwwroot") + filePath;
                        pathImage[index] = filePath;
                        using (var stream = System.IO.File.Create(filePathFull))
                        {
                            formFile.CopyTo(stream);
                        }
                        index++;
                    }
                }
            }
            return pathImage;
        }
	}
}
