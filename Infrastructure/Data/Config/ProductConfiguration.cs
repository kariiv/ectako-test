using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Infrastructure.Data.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EctakoTest.Infrastructure.Data.Config;

public class PersonConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();
        
        builder.Property(p => p.Price)
            .IsRequired();
        
        builder.Property(p => p.GroupId)
            .IsRequired();

        builder.Property(p => p.PriceWithVat)
            .IsRequired();
        
        builder.Property(p => p.VatRate)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasValueGenerator<TimeNowGenerator>();
        
        builder.Property(p => p.UpdatedAt)
            .IsRequired()
            .ValueGeneratedOnUpdate()
            .HasValueGenerator<TimeNowGenerator>();
        
        builder.HasIndex(p => p.Name)
            .IsUnique();
        
        builder.HasOne(p => p.Group)
            .WithMany(g => g.Products);

        builder.HasMany(s => s.Stores)
            .WithMany(c => c.Products);
    }
}