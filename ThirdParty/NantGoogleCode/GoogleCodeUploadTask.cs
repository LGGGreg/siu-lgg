using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
namespace NantGoogleCode
{
	public class GoogleCodeUploadTask
	{
		private static readonly byte[] NewLineAsciiBytes = Encoding.ASCII.GetBytes("\r\n");
		private static readonly string Boundary = Guid.NewGuid().ToString();
		private string _userName;
		private string _password;
		private string _projectName;
		private string _fileName;
		private string _targetFileName;
		private string _summary;

		/// <summary>
		/// Gets or sets Google user name to authenticate as (this is just the username part, don't include the @gmail.com part.
		/// </summary>
		//[TaskAttribute("username", Required = true)]
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; }
		}

		/// <summary>
		/// Gets or sets the Google Code password (not the same as the gmail password).
		/// </summary>
		//[TaskAttribute("password", Required = true)]
		public string Password 
		{
			get { return _password; }
			set { _password = value; }
		}

		/// <summary>
		/// Gets or sets the Google Code project name to upload to.
		/// </summary>
		//[TaskAttribute("projectname", Required = true)]
		public string ProjectName 
		{
			get { return _projectName; }
			set { _projectName = value; }
		}

		/// <summary>
		/// Gets or sets the local path of the file to upload.
		/// </summary>
		//[TaskAttribute("filename", Required = true)]
		public string FileName 
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		/// <summary>
		/// Gets or sets the file name that this file will be given on Google Code.
		/// </summary>
		//[TaskAttribute("targetfilename", Required = true)]
		public string TargetFileName 
		{
			get { return _targetFileName; }
			set { _targetFileName = value; }
		}

		/// <summary>
		/// Gets or sets the summary of the upload.
		/// </summary>
		//[TaskAttribute("summary", Required = true)]
		public string Summary 
		{
			get { return _summary; }
			set { _summary = value; }
		}

		/// <summary>
		/// Executes the upload task.
		/// </summary>
		public void ExecuteTask()
		{
			try
			{
				if (UserName == null)
					throw new InvalidOperationException("UserName cannot be null");

				if (Password == null)
					throw new InvalidOperationException("Password cannot be null");

				if (ProjectName == null)
					throw new InvalidOperationException("ProjectName cannot be null");

				if (FileName == null)
					throw new InvalidOperationException("FileName cannot be null");

				if (TargetFileName == null)
					throw new InvalidOperationException("TargetFileName cannot be null");

				if (Summary == null)
					throw new InvalidOperationException("Summary cannot be null");

				Upload();
			}
			catch (Exception e)
			{
				//Project.Log(Level.Error, e.Message, e);
				throw;
			}

			//Project.Log(Level.Info, "Upload task completed successfully.");
		}

		/// <summary>
		/// Uploads the contents of the file to the project's Google Code upload url. 
		/// Performs the basic http authentication required by Google Code.
		/// </summary>
		public void Upload()
		{
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(String.Format("https://{0}.googlecode.com/files", ProjectName));
			request.Method = "POST";
			request.ContentType = String.Concat("multipart/form-data; boundary=" + Boundary);
			request.UserAgent = String.Concat("Google Code Upload Nant Task ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
			request.Headers.Add("Authorization", String.Concat("Basic ", CreateAuthorizationToken(UserName, Password)));

			/*Project.Log(Level.Info, request.UserAgent);
			Project.Log(Level.Info, String.Concat("Upload URL: ", request.Address.ToString()));
			Project.Log(Level.Info, String.Concat("Username: ", UserName));
			Project.Log(Level.Info, String.Concat("File to send: ", FileName));
			Project.Log(Level.Info, String.Concat("Target file: ", TargetFileName));
			Project.Log(Level.Info, String.Concat("Summary: ", Summary));*/

			using (Stream stream = request.GetRequestStream())
			{
				//Project.Log(Level.Info, "Sending summary...");
				WriteLine(stream, String.Concat("--", Boundary));
				WriteLine(stream, @"content-disposition: form-data; name=""summary""");
				WriteLine(stream, "");
				WriteLine(stream, Summary);

				//Project.Log(Level.Info, "Sending file...");
				WriteLine(stream, String.Concat("--", Boundary));
				WriteLine(stream, String.Format(@"content-disposition: form-data; name=""filename""; filename=""{0}""", TargetFileName));
				WriteLine(stream, "Content-Type: application/octet-stream");
				WriteLine(stream, "");
				WriteFile(stream, FileName);
				WriteLine(stream, "");
				WriteLine(stream, String.Concat("--", Boundary, "--"));
			}

			request.GetResponse();
		}

		/// <summary>
		/// Writes the specified file to the specified stream.
		/// </summary>
		internal void WriteFile(Stream outputStream, string fileToWrite)
		{
			if (outputStream == null)
				throw new ArgumentNullException("outputStream");

			if (fileToWrite == null)
				throw new ArgumentNullException("fileToWrite");

			using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
			{
				byte[] buffer = new byte[1024];
				int count;
				while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputStream.Write(buffer, 0, count);
				}
			}
		}

		/// <summary>
		/// Writes the string to the specified stream and concatenates a newline.
		/// </summary>
		internal static void WriteLine(Stream outputStream, string valueToWrite)
		{
			if (valueToWrite == null)
				throw new ArgumentNullException("valueToWrite");

			List<byte> bytesToWrite = new List<byte>(Encoding.ASCII.GetBytes(valueToWrite));
			bytesToWrite.AddRange(NewLineAsciiBytes);
			outputStream.Write(bytesToWrite.ToArray(), 0, bytesToWrite.Count);
		}

		/// <summary>
		/// Creates the authorization token.
		/// </summary>
		internal static string CreateAuthorizationToken(string username, string password)
		{
			if (username == null)
				throw new ArgumentNullException("username");

			if (password == null)
				throw new ArgumentNullException("password");

			byte[] authBytes = Encoding.ASCII.GetBytes(String.Concat(username, ":", password));
			return Convert.ToBase64String(authBytes);
		}
	}
}