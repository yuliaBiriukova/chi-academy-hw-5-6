using HW_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_6.Configurations
{
    internal class AnalysisEntityConfiguration : IEntityTypeConfiguration<Analysis>
    {
        public void Configure(EntityTypeBuilder<Analysis> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired().HasMaxLength(124);

            builder.Property(a => a.Cost).IsRequired();

            builder.Property(a => a.Price).IsRequired();

        }
    }
}