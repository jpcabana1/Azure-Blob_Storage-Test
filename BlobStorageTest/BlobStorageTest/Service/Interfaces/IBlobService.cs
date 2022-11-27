using Azure.Storage.Blobs.Models;
using Azure;

namespace BlobStorageTest.Service.Interfaces;
public interface IBlobService
{
    Task<string> Download(string blobName);
    Task<Response<BlobContentInfo>> Upload(IFormFile file);
}

