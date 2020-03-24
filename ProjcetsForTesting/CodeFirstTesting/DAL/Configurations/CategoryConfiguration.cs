using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;
using DAL.SeedingDataExtension;

namespace DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(ProductsContextExtensionSeed.SeedData<Category>("Categories.json"));
        }
    }
}
