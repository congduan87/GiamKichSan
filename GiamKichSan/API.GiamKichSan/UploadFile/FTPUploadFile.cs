using API.GiamKichSan.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;

namespace API.GiamKichSan.UploadFile
{
	public class FTPUploadFile
	{
		private FTPModel fTPModel { get; set; }
		public FTPUploadFile(FTPModel fTPModel)
		{
			this.fTPModel = fTPModel;
		}

		#region PrivateCommon
		private FtpWebRequest InitFTPWebRequest(string path, string webRequestMethod)
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", fTPModel.Server, path));
			request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
			request.Method = webRequestMethod;
			request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);
			request.KeepAlive = false;
			request.UseBinary = true;
			request.UsePassive = true;
			return request;
		}
		private string[] GetDirectoriesInPath(string pathDirectory)
		{
			return pathDirectory.Replace("/", "\\").Split('\\');
		}
		#endregion

		public ResObject<bool> ExistsDirectory(string fileFolder = "")
		{
			ResObject<bool> output = new ResObject<bool>();
			try
			{
				if (fileFolder.Trim() == "")
				{
					output.obj = false;
					output.codeError = "-1";
					output.strError = "Không tồn tại thư mục";
					return output;
				}

				FtpWebRequest request = InitFTPWebRequest(fileFolder, WebRequestMethods.Ftp.ListDirectory);
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				response.Close();
				output.obj = true;
			}
			catch (Exception ex)
			{
				output.obj = false;
				Console.WriteLine(string.Format("FTPUploadFile_ExistsDirectory: {0}", ex.ToString()));

			}
			return output;
		}

		public ResObject<bool> CreateDirectory(string directory)
		{
			ResObject<bool> output = new ResObject<bool>();
			try
			{
				output = ExistsDirectory(directory);
				if (output.isValidate && Convert.ToBoolean(output.obj))
				{
					return output;
				}

				FtpWebRequest request = InitFTPWebRequest(directory, WebRequestMethods.Ftp.MakeDirectory);
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				ftpStream.Close();
				response.Close();
				output.obj = true;
			}
			catch (WebException ex)
			{
				FtpWebResponse response = (FtpWebResponse)ex.Response;
				if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
				{
					response.Close();
					output.obj = true;
				}
				else
				{
					response.Close();
				}
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_CreateDirectory: {0}", ex.ToString());
			}
			return output;
		}

		public ResObject<bool> CreateDirectories(string directory)
		{
			ResObject<bool> output = new ResObject<bool>();
			output = ExistsDirectory(directory);
			if (output.isValidate && Convert.ToBoolean(output.obj))
			{
				return output;
			}

			var arrDirectory = GetDirectoriesInPath(directory);
			var currentDirectory = "";
			for (int indexDirectory = arrDirectory.Length - 1; indexDirectory >= 0; indexDirectory--)
			{
				if (!string.IsNullOrEmpty(arrDirectory[indexDirectory]))
				{
					currentDirectory = string.IsNullOrWhiteSpace(currentDirectory) ? arrDirectory[indexDirectory] : Path.Combine(currentDirectory, arrDirectory[indexDirectory]);
					output = CreateDirectory(currentDirectory);
					if (!output.isValidate || !Convert.ToBoolean(output.obj))
					{
						return output;
					}
				}
			}
			return output;
		}

		public async Task<ResObject<bool>> FileUpload(Stream fileStream, string fileName, string directoryServer)
		{
			ResObject<bool> output = new ResObject<bool>() { obj = false };
			try
			{
				if (fileStream == null)
				{
					throw new Exception("File is null");
				}

				if (fileName == null)
				{
					throw new Exception("FileName is null");
				}

				output = CreateDirectories(directoryServer);
				if (!output.isValidate || !Convert.ToBoolean(output.obj))
				{
					return output;
				}

				FtpWebRequest request = InitFTPWebRequest(Path.Combine(directoryServer, fileName), WebRequestMethods.Ftp.UploadFile);
				Stream requestStream = request.GetRequestStream();
				await fileStream.CopyToAsync(requestStream);
				requestStream.Close();
				fileStream.Close();

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
				response.Close();
				output.obj = true;
			}
			catch (WebException e)
			{
				String status = ((FtpWebResponse)e.Response).StatusDescription;
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileUpload {0}: {1} \n {1}", fileName, status, e.ToString());
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FolderUpload: {0}", ex.ToString());
			}
			return output;
		}

		public async Task<ResObject<bool>> FileUpload(FileStream fileStream, string directoryServer)
		{
			return await FileUpload(fileStream as Stream, fileStream.Name, directoryServer);
		}

		public async Task<ResObject<bool>> FileUpload(string UploadURL, string directoryServer)
		{
			ResObject<bool> output = new ResObject<bool>() { obj = false };
			try
			{
				if (string.IsNullOrEmpty(UploadURL))
				{
					output.obj = false;
					output.codeError = "-1";
					output.strError = "UploadURL is null";
					return output;
				}

				FileStream fileStream = File.OpenRead(UploadURL);
				return await FileUpload(fileStream, directoryServer);
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileUpload: {0}", ex.ToString());
			}
			return output;
		}

		public async Task<ResObject<bool>> FolderUpload(string UploadURL, string directoryServer)
		{
			ResObject<bool> output = new ResObject<bool>() { obj = false };
			try
			{
				if (string.IsNullOrEmpty(UploadURL))
				{
					output.obj = false;
					output.codeError = "-1";
					output.strError = "UploadURL is null";
					return output;
				}

				foreach (var itemUrl in Directory.GetFiles(UploadURL))
				{
					output = await FileUpload(itemUrl, directoryServer);
					if (!output.isValidate)
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileUpload: {0}", ex.ToString());
			}
			return output;
		}

		public async Task<ResObject<byte>> FileStreamDownload(string downloadURL)
		{
			ResObject<byte> output = new ResObject<byte>();

			try
			{
				if (string.IsNullOrEmpty(downloadURL))
				{
					throw new Exception("fileName is null");
				}

				FtpWebRequest request = InitFTPWebRequest(downloadURL, WebRequestMethods.Ftp.DownloadFile);
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				if (responseStream is MemoryStream)
				{
					output.arrObj = ((MemoryStream)responseStream).ToArray();
				}
				else
				{
					using (var memoryStream = new MemoryStream())
					{
						await responseStream.CopyToAsync(memoryStream);
						output.arrObj = memoryStream.ToArray();
					}
				}
				responseStream.Dispose();
				responseStream.Close();
				response.Close();
			}
			catch (WebException e)
			{
				String status = ((FtpWebResponse)e.Response).StatusDescription;
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileStreamDownload: {0} \n {1}", status, e.ToString());
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileStreamDownload: {0}", ex.ToString());
			}
			return output;
		}

		public ResObject<bool> FolderDownload(string DownloadURL, string ClientURL)
		{
			ResObject<bool> output = new ResObject<bool>() { obj = false };
			try
			{
				if (string.IsNullOrEmpty(DownloadURL))
				{
					throw new Exception("fileName is null");
				}

				if (string.IsNullOrEmpty(ClientURL))
				{
					throw new Exception("fileName is null");
				}

				DownloadURL = DownloadURL.TrimStart(new char[] { '\\', '/' });

				var nameFile = DownloadURL.Replace("\\", "/").Split('/');

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", fTPModel.Server, DownloadURL));
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				request.Method = WebRequestMethods.Ftp.ListDirectory;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);

				request.KeepAlive = false;
				request.UseBinary = true;
				request.UsePassive = true;

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader srd = new StreamReader(responseStream);

				while (!srd.EndOfStream)
				{
					FileDownload(Path.Combine(DownloadURL, srd.ReadLine()), ClientURL);
				}

				responseStream.Dispose();
				responseStream.Close();

				response.Close();
				output.obj = true;
			}
			catch (WebException e)
			{
				String status = ((FtpWebResponse)e.Response).StatusDescription;
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FolderDownload: {0} \n {1}", status, e.ToString());
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FolderDownload: {0}", ex.ToString());
			}
			return output;
		}

		public ResObject<bool> FileDownload(string DownloadURL, string ClientURL, string FileName = "")
		{
			ResObject<bool> output = new ResObject<bool>() { obj = false };
			try
			{
				if (string.IsNullOrEmpty(DownloadURL))
				{
					throw new Exception("fileName is null");
				}

				if (string.IsNullOrEmpty(ClientURL))
				{
					throw new Exception("fileName is null");
				}
				DownloadURL = DownloadURL.TrimStart(new char[] { '\\', '/' });

				var nameFile = string.IsNullOrEmpty(FileName) ? DownloadURL.Replace("\\", "/").Split('/') : new string[] { FileName };

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", fTPModel.Server, DownloadURL));
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				request.Method = WebRequestMethods.Ftp.DownloadFile;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);

				request.KeepAlive = false;
				request.UseBinary = true;
				request.UsePassive = true;

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();


				if (File.Exists(Path.Combine(ClientURL, nameFile[nameFile.Length - 1])))
				{
					File.Delete(Path.Combine(ClientURL, nameFile[nameFile.Length - 1]));
				}

				Stream fileStream = new FileStream(Path.Combine(ClientURL, nameFile[nameFile.Length - 1]), FileMode.Create);
				responseStream.CopyTo(fileStream);

				responseStream.Dispose();
				responseStream.Close();

				fileStream.Dispose();
				fileStream.Close();

				response.Close();
				output.obj = true;
			}
			catch (WebException e)
			{
				String status = ((FtpWebResponse)e.Response).StatusDescription;
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileDownload: {0} \n {1}", status, e.ToString());
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FileDownload: {0}", ex.ToString());
			}
			return output;
		}
	}
}
