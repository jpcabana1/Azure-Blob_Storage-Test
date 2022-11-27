using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorageTest.Service.Interfaces;
using BlobStorageTest.Utils;
using System.Xml;

namespace BlobStorageTest.Service;
public class BlobService : IBlobService
{
    private readonly BlobContainerClient _blobContainerClient;
    private const string RootPath = "HealthAccounts/";
    public BlobService(BlobContainerClient blobContainerClient)
    {
        _blobContainerClient = blobContainerClient;
    }
    public async Task<string> Download(string blobName)
    {
        var blob = _blobContainerClient.GetBlobClient(RootPath+blobName);
        var memorystream = new MemoryStream();
        await blob.DownloadToAsync(memorystream);
        memorystream.Position = 0;

        var xml = new XmlDocument();
        xml.Load(memorystream);
        return xml.InnerXml;
    }

    public async Task<Response<BlobContentInfo>> Upload(IFormFile file)
    {
        var blobName = CreateBlobUtil.GetNewBlobFileName(file.FileName);
        
        var blob = _blobContainerClient.GetBlobClient(RootPath + blobName);
        return await blob.UploadAsync(file.OpenReadStream());
    }
}

