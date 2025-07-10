using Microsoft.Extensions.Options;

namespace azureBlobApi.Infrastructure.Integrations.BlobStorage;

public class UploadService : BlobService
{
    public UploadService(IOptions<BlobStorageConfiguration> configuration) : base(configuration)
    {
    }

    public async Task DeleteAsync(string containerName, string fileName, CancellationToken cancellationToken = default)
    {
        var blobContainer = await CreateIfNotExistsAsync(containerName, cancellationToken);
        var blockBlob = blobContainer.GetBlobClient(fileName);

        await blockBlob.DeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<string> UploadAsync(string containerName, string fileName, Stream fileStream, CancellationToken cancellationToken = default)
    {
        var blobContainer = await CreateIfNotExistsAsync(containerName, cancellationToken);
        var blockBlob = blobContainer.GetBlobClient(fileName);

        fileStream.Seek(0, SeekOrigin.Begin);

        await blockBlob.UploadAsync(fileStream, true, cancellationToken);

        return blockBlob.Uri.LocalPath;
    }
}
