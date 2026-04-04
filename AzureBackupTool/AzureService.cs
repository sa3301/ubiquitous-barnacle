using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Security.Cryptography;

public class AzureService
{
    private readonly string connectionString = "AzureStorageConnectionStringHere";
    private readonly string containerName = "backups";

    private BlobContainerClient GetContainerClient()
    {
        var client = new BlobContainerClient(connectionString, containerName);
        client.CreateIfNotExists();
        return client;
    }

    // Helper method for SHA-256 hash
    public string ComputeSHA256(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hashBytes = sha256.ComputeHash(stream);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    public async Task UploadFileAsync(string filePath)
    {
        var container = GetContainerClient();
        var fileName = Path.GetFileName(filePath);
        var blobClient = container.GetBlobClient(fileName);

        // Compute SHA-256 before upload
        var localHash = ComputeSHA256(filePath);
        Console.WriteLine($"Local SHA-256: {localHash}");

        await blobClient.UploadAsync(filePath, true);
        Console.WriteLine($"Uploaded: {fileName}");

        // verify by downloading immediately
        string tempDownload = "temp_" + fileName;
        await blobClient.DownloadToAsync(tempDownload);
        var remoteHash = ComputeSHA256(tempDownload);
        Console.WriteLine($"Remote SHA-256: {remoteHash}");
        File.Delete(tempDownload);
        if (localHash == remoteHash)
        {
            Console.WriteLine("Upload verified successfully.");
        }
        else
        {
            Console.WriteLine("Upload verification failed!");
        }
    }

    public async Task ListFilesAsync()
    {
        var container = GetContainerClient();
        await foreach (var blobItem in container.GetBlobsAsync())
        {
            Console.WriteLine(blobItem.Name);
        }
    }

    public async Task DownloadFileAsync(string fileName)
    {
        var container = GetContainerClient();
        var blobClient = container.GetBlobClient(fileName);
        await blobClient.DownloadToAsync(fileName);
        Console.WriteLine($"Downloaded: {fileName}");
    }

    public async Task MigrateFileAsync(string filePath)
    {
        var container = GetContainerClient();
        var fileName = Path.GetFileName(filePath);
        var originalBlob = container.GetBlobClient(fileName);
        var newName = Path.GetFileNameWithoutExtension(fileName) + "-migrated" + Path.GetExtension(fileName);
        var newBlob = container.GetBlobClient(newName);

        await newBlob.StartCopyFromUriAsync(originalBlob.Uri);
        Console.WriteLine($"Migrated: {fileName} -> {newName}");
    }

    public async Task AutoMigrateAllAsync()
    {
        var container = GetContainerClient();
        await foreach (var blobItem in container.GetBlobsAsync())
        {
            var originalBlob = container.GetBlobClient(blobItem.Name);
            var newName = Path.GetFileNameWithoutExtension(blobItem.Name) + "-migrated" + Path.GetExtension(blobItem.Name);
            var newBlob = container.GetBlobClient(newName);

            await newBlob.StartCopyFromUriAsync(originalBlob.Uri);
            Console.WriteLine($"Migrated: {blobItem.Name} -> {newName}");
        }
    }
}