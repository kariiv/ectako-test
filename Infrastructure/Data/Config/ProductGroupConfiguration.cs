using EctakoTest.Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EctakoTest.Infrastructure.Data.Config;

class PersonParentConfiguration : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.ToTable("ProductGroup");
        
        builder.HasKey(pp => new {pp.Id});

        builder.Property(p => p.Name)
            .IsRequired();
        
        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}