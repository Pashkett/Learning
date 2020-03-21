using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;

namespace DAL.Configurations
{
    public class SupplierConfiguartion : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.SupplierId);

            builder.Property(s => s.SupplierName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.City)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
