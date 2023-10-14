using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

public class GoogleDriveApi
{
    private const string folderId = "1Na6UFfyNd95gF0MutL3TV1MuJc1vy-M-";
    private const string applicationName = "MyProject";

    public void DownloadFolder(string downloadPath, string credentialsPath)
    {
        UserCredential credential;

        using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
        {
            string credPath = "credentials.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.DriveReadonly },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName,
        });

        var request = service.Files.List();
        request.Q = $"'{folderId}' in parents";
        var files = request.Execute().Files;

        foreach (var file in files)
        {
            DownloadFile(service, file.Id, Path.Combine(downloadPath, file.Name));
        }
    }

    private void DownloadFile(DriveService service, string fileId, string downloadPath)
    {
        var request = service.Files.Get(fileId);
        var stream = new MemoryStream();
        request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
        {
            Console.WriteLine($"Downloaded {progress.BytesDownloaded} bytes");
        };
        request.Download(stream);

        using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
        {
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
        }
    }
}
