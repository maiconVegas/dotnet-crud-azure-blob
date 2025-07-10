using azureBlobApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace azureBlobApi.Infrastructure.Data.Configuration;

public class FileBlobConfiguration : IEntityTypeConfiguration<FileBlob>
{
    public void Configure(EntityTypeBuilder<FileBlob> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
