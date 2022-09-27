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
		public FTPUploadFile(IConfiguration config)
		{
			fTPModel = config.GetValue<FTPModel>("FTPUpload");
		}
		public ResObject ExistsDirectory(string fileFolder = "")
		{
			ResObject output = new ResObject();
			try
			{
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", fTPModel.Server, fileFolder));
				request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);
				request.KeepAlive = false;
				request.UseBinary = true;
				request.UsePassive = true;
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				response.Close();
				output.obj = true;
			}
			catch (Exception ex)
			{
				output.obj = false;
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_ExistsDirectory: {0}", ex.ToString());
			}
			return output;
		}

		public ResObject CreateDirectory(string directory)
		{
			ResObject output = new ResObject();
			try
			{
				output = ExistsDirectory(directory);
				if (output.isValidate && Convert.ToBoolean(output.obj))
				{
					return output;
				}

				var listDirectory = new List<String>();
				var arrayDirectory = directory.Replace("/", "\\").Split('\\').ToList<String>();

				var newDirectory = "";
				var indexRemove = 0;
				var indexError = 0;

				while (arrayDirectory.Count > 0)
				{
					newDirectory = "";
					indexRemove = arrayDirectory.Count - 1;
					if (!string.IsNullOrEmpty(arrayDirectory[indexRemove]))
					{
						newDirectory = Path.Combine(string.Join("\\", arrayDirectory));
						output = ExistsDirectory(newDirectory);
						if (output.isValidate && Convert.ToBoolean(output.obj))
						{
							break;
						}
					}
					listDirectory.Add(newDirectory);
					arrayDirectory.RemoveAt(indexRemove);

					indexError++;
					if (indexError > 200)
					{
						throw new Exception("Function is looped");
					}
				}

				for (int i = listDirectory.Count; i > 0; i--)
				{
					if (!string.IsNullOrEmpty(listDirectory[i - 1]))
					{
						FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("ftp://{0}/{1}", fTPModel.Server, listDirectory[i - 1])));
						request.Method = WebRequestMethods.Ftp.MakeDirectory;
						request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);
						request.UsePassive = true;
						request.UseBinary = true;
						request.KeepAlive = false;

						FtpWebResponse response = (FtpWebResponse)request.GetResponse();
						Stream ftpStream = response.GetResponseStream();

						ftpStream.Close();
						response.Close();
					}
				}

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

		public async Task<ResObject> FileUpload(Stream fileStream, string fileName, string directoryServer)
		{
			ResObject output = new ResObject() { obj = false };
			try
			{
				if (fileStream == null)
				{
					throw new Exception("fileName is null");
				}

				output = CreateDirectory(directoryServer);
				if (!output.isValidate || Convert.ToBoolean(output.obj))
				{
					return output;
				}

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}/{2}", fTPModel.Server, directoryServer, fileName));
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				request.Method = WebRequestMethods.Ftp.UploadFile;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);

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

		public ResObject FileUpload(FileStream fileStream, string directoryServer)
		{
			ResObject output = new ResObject() { obj = false };

			try
			{
				if (fileStream == null)
				{
					throw new Exception("fileName is null");
				}

				output = CreateDirectory(directoryServer);
				if (!output.isValidate || Convert.ToBoolean(output.obj))
				{
					return output;
				}

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}/{2}", fTPModel.Server, directoryServer, fileStream.Name));
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				request.Method = WebRequestMethods.Ftp.UploadFile;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);

				Stream requestStream = request.GetRequestStream();
				fileStream.CopyTo(requestStream);
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
				output.strError = string.Format("FTPUploadFile_FileUpload {0}: {1} \n {1}", fileStream.Name, status, e.ToString());
			}
			catch (Exception ex)
			{
				output.codeError = "99";
				output.strError = string.Format("FTPUploadFile_FolderUpload: {0}", ex.ToString());
			}
			return output;
		}

		public ResObject FileUpload(string UploadURL, string directoryServer)
		{
			ResObject output = new ResObject() { obj = false };

			if (string.IsNullOrEmpty(UploadURL))
			{
				throw new Exception("fileName is null");
			}

			FileStream fileStream = File.OpenRead(UploadURL);
			output = FileUpload(fileStream, directoryServer);

			return output;
		}

		public ResObject FolderUpload(string UploadURL, string directoryServer)
		{
			ResObject output = new ResObject() { obj = false };

			if (string.IsNullOrEmpty(UploadURL))
			{
				throw new Exception("fileName is null");
			}

			foreach (var itemUrl in Directory.GetFiles(UploadURL))
			{
				output = FileUpload(itemUrl, directoryServer);
				if (!output.isValidate || !Convert.ToBoolean(output.obj))
				{
					break;
				}
			}
			return output;
		}

		public ResObject FileStreamDownload(string downloadURL)
		{
			ResObject output = new ResObject() { obj = null };

			try
			{
				if (string.IsNullOrEmpty(downloadURL))
				{
					throw new Exception("fileName is null");
				}
				downloadURL = downloadURL.TrimStart(new char[] { '\\', '/' });
				var nameFile = downloadURL.Replace("\\", "/").Split('/');

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", fTPModel.Server, downloadURL));
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				request.Method = WebRequestMethods.Ftp.DownloadFile;
				request.Credentials = new NetworkCredential(fTPModel.Username, fTPModel.Password);

				request.KeepAlive = false;
				request.UseBinary = true;
				request.UsePassive = true;

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
						responseStream.CopyTo(memoryStream);
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

		public ResObject FolderDownload(string DownloadURL, string ClientURL)
		{
			ResObject output = new ResObject() { obj = false };
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

		public ResObject FileDownload(string DownloadURL, string ClientURL, string FileName = "")
		{
			ResObject output = new ResObject() { obj = false };
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
