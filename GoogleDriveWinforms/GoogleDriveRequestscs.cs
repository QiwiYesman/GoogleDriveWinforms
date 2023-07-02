using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Download;
//using Google.Apis.Util;
//using Google.Apis.Util.Store;
using Google.Apis.Drive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Requests.Parameters;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using System.Net;
using System.Net.Mime;

namespace GoogleDriveWinforms
{
    using static Google.Apis.Requests.BatchRequest;
    using DriveFile = Google.Apis.Drive.v3.Data.File;
    internal class GoogleDriveRequests
    {
        HttpClient httpClient = new();
        private const string CredentialsPath = @".\someFiles\credentials.json";
        string clientId = "візьми сам при вході";
        string clientSecret = "візьми сам при вході";
        string tokenPath = @".\someFiles";
        string[] scopes = { DriveService.Scope.Drive };
        UserCredential userCredentials;
        DriveService service;

        public DriveFile Upload(string filePath, string parentId ="root")
        {
            using var stream = new FileStream(filePath,
                      FileMode.Open);
            string fileName = Path.GetFileName(filePath);
            return Upload(stream, fileName, parentId);

        }
        public DriveFile Upload(Stream stream, string fileName, string parentId="root")
        {
            
            var fileMetadata = new DriveFile()
            {
                Name = fileName,
                Parents = new List<string>() { parentId }
            };
            FilesResource.CreateMediaUpload request;

            request = service.Files.Create(
                fileMetadata, stream, "application/unknown");
            request.Fields = "id";
            request.Upload();
            return fileMetadata;
        }
        public async Task<Stream> GetUrlStream(string url)
        {
            var response = await httpClient.GetAsync(url);            
            response.EnsureSuccessStatusCode();
            var headers = response.Content.Headers;
            MessageBox.Show(new Uri(url).LocalPath);
            var s =await response.Content.ReadAsStreamAsync();
            return s;

        }

        public async void Login(string userName)
        {
            ClientSecrets secrets = new()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            userCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                scopes,
                userName,
                CancellationToken.None,
                new FileDataStore(tokenPath, true)
              );
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredentials,
            });
            MessageBox.Show("Connected");
        }

        public static DriveFile CreateFolder(DriveService service, string title, string parentId)
        {
            DriveFile body = new()
            {
                Name = title,
                Parents = new List<string> { parentId },
                MimeType = "application/vnd.google-apps.folder"
            };
            return service.Files.Create(body).Execute();
        }

        public DriveFile CreateFolder(string title, string parentId)=>
            CreateFolder(service, title, parentId);
        
        public void Move(string fileId, string folderId, string previousFolder)
        {
            var updateRequest = service.Files.Update(null, fileId);
            updateRequest.AddParents = folderId;
            updateRequest.RemoveParents = previousFolder;
            updateRequest.Execute();
        }
        public static bool isFolder(string fileType) =>
            fileType == "application/vnd.google-apps.folder";

        public static bool isShortcut(string fileType) =>
            fileType == "application/vnd.google-apps.shortcut";

        public async void LoadTree(string parentId, TreeNode treeNode)
        {
            treeNode.Nodes.Clear();
            var request = service.Files.List();
            request.PageSize = 1000;
            request.Q = $"'{parentId}' in parents and trashed=false";
            request.Fields = "files(id, name, size, mimeType, parents, shortcutDetails)";
            var results = await request.ExecuteAsync();
            var files = OrderByFolder(results.Files);
            foreach (var file in files)
            {
                TreeNode item = new FileInfo(file, parentId);
                treeNode.Nodes.Add(item);
                if (isFolder(file.MimeType))
                {
                    LoadTree(file.Id,item);
                }
            }
        }

        public static MemoryStream ExportFile(DriveService service, string fileId, string fileType, Action<double>? ProgressHandler = null)
        {
            var sizeRequest = service.Files.Get(fileId);
            var file = sizeRequest.Execute();
            var request = service.Files.Export(fileId, fileType);
            
            //request.
            var stream = new MemoryStream();
            double size = file.Size ?? 1.0;
            if (ProgressHandler != null)
            {
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    double downloaded = Math.Round(progress.BytesDownloaded / size * 100, 2);
                                    ProgressHandler(downloaded);
                                    MessageBox.Show(downloaded.ToString());
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    ProgressHandler(100);
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    ProgressHandler(-1);
                                    break;
                                }
                        }

                    };
            }
            //request.Download(stream);
            var s = request.DownloadWithStatus(stream);
            //if(s!= null) MessageBox.Show(s.Status.ToString() + s.Exception.Message);
            return stream;
        }

        public static MemoryStream DownloadFile(DriveService service, string fileId, Action<double>? ProgressHandler=null)
        {
            var sizeRequest = service.Files.Get(fileId);
            //sizeRequest.Fields = "size";
            var file = sizeRequest.Execute();
            double size = file.Size ?? 1;
            var request = service.Files.Get(fileId);
            var stream = new MemoryStream();
            if (ProgressHandler != null)
            {
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    double downloaded = Math.Round(progress.BytesDownloaded/size *100, 2);
                                    ProgressHandler(Math.Round(progress.BytesDownloaded/ size * 100, 2));
                                    MessageBox.Show(downloaded.ToString());
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    ProgressHandler(100);
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    ProgressHandler(-1);
                                    break;
                                }
                        }

                    };
            }
            request.Download(stream);
            return stream;
        }
        public MemoryStream DownloadFile(string fileId, Action<double>? ProgressHandler = null)=>
            DownloadFile(service, fileId, ProgressHandler);
        
        public MemoryStream ExportFile(string fileId, string fileType, Action<double>? ProgressHandler = null)=>
            ExportFile(service, fileId, fileType, ProgressHandler);

        public static async void RemoveFile(DriveService service, string fileId)
        {
            var request = service.Files.Delete(fileId);
            await request.ExecuteAsync();
        }

        public void RemoveFile(string fileId)
        {
            RemoveFile(service, fileId);
        }

        public static string CorrectFileName(string fileName) =>
            string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));

        public static void Save(MemoryStream stream, string filePath)
        {
            using FileStream fileStream = new(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            stream.WriteTo(fileStream);
        }
        public static IList<DriveFile> OrderByFolder(IList<DriveFile> files)
        {
            return files.OrderBy(x => !isFolder(x.MimeType)).ToList();
        }
    }
}
