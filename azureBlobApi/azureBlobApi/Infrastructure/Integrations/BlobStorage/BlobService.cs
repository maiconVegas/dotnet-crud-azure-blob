﻿using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace azureBlobApi.Infrastructure.Integrations.BlobStorage;

public class BlobService
{
    public readonly BlobServiceClient BlobServiceClient;

    public BlobService(IOptions<BlobStorageConfiguration> configuration)
    {
        BlobServiceClient = new BlobServiceClient(configuration.Value.ConnectionString);
    }

    public async Task<List<string>> ListBlobsAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var blobContainer = BlobServiceClient.GetBlobContainerClient(containerName);
        var blobs = new List<string>();
        await foreach (var blob in blobContainer.GetBlobsAsync(cancellationToken: cancellationToken))
        {
            blobs.Add(blob.Name);
        }
        return blobs;
    }

    public async Task<bool> ExistsAsync(string containerName, string fileName, CancellationToken cancellationToken = default)
    {
        var blobContainer = BlobServiceClient.GetBlobContainerClient(containerName);
        var blockBlob = blobContainer.GetBlobClient(fileName);

        return await blockBlob.ExistsAsync(cancellationToken);
    }

    public async Task DeleteIfExistsBlobContainerAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var blobContainer = await CreateIfNotExistsAsync(containerName, cancellationToken);
        await blobContainer.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }

    public async Task<BlobContainerClient> CreateIfNotExistsAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var blobContainer = BlobServiceClient.GetBlobContainerClient(containerName);
        await blobContainer.CreateIfNotExistsAsync(publicAccessType: PublicAccessType.None, cancellationToken: cancellationToken);

        return blobContainer;
    }
}
