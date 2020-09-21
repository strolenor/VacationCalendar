using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeVacationCalendar.Data.Configuration
{
    public class PageFieldConfiguration : IEntityTypeConfiguration<PageField>
    {
        public void Configure(EntityTypeBuilder<PageField> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.DefaultValue).HasMaxLength(100).HasDefaultValue("").IsRequired(true);
            builder.HasOne(x => x.Teplate).WithMany().HasForeignKey(y => y.TeplateId).IsRequired(true);
        }
    }
}