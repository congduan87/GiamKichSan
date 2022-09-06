using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GiamKichSan.Common
{
	public class LogFile
	{
		public static string rootPath = Path.GetFullPath(@"wwwroot\fileTemp");

		public static void SaveFile(string fileName, string description)
		{
            try
            {
                var fileSave = Path.Combine(rootPath, fileName + ".txt");     
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}/{2}", "112.78.2.96", "FTP", fileName + ".txt"));
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("gia28291", "M@tKhauM0i");

                Stream requestStream = request.GetRequestStream();
                Byte[] title = new UTF8Encoding(true).GetBytes(description);
                requestStream.Write(title, 0, title.Length);

                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
	}
}
