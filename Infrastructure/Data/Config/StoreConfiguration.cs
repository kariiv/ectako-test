using EctakoTest.Core.Entities.StoreAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EctakoTest.Infrastructure.Data.Config;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Store");

        builder.HasKey(p => p.Id);
        
        builder.HasIndex(p => p.Name)
            .IsUnique();
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);
    }
}