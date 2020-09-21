using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeVacationCalendar.Data.Configuration
{
    public class PageFieldTranslationConfiguration : IEntityTypeConfiguration<PageFieldTranslation>
    {
        public void Configure(EntityTypeBuilder<PageFieldTranslation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Value).HasMaxLength(100).HasDefaultValue("").IsRequired(true);
            builder.HasOne(x => x.Template).WithMany().HasForeignKey(y => y.TeplateIdId).IsRequired(true);
            builder.HasOne(x => x.Field).WithMany().HasForeignKey(y => y.FieldId).IsRequired(true);
            builder.HasOne(x => x.Country).WithMany().HasForeignKey(y => y.CountryId).IsRequired(true);
        }
    }
}