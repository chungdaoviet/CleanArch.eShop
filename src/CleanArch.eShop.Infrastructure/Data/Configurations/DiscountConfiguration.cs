using CleanArch.eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.eShop.Infrastructure.Data.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts");
        
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(d => d.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.HasOne(d => d.Product)
            .WithOne(p => p.Discount)
            .HasForeignKey<Product>(p => p.DiscountId);
    }
}