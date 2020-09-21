using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeVacationCalendar.Data.Configuration
{
    public class PageTemplateConfiguration : IEntityTypeConfiguration<PageTemplate>
    {
        public void Configure(EntityTypeBuilder<PageTemplate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
        }
    }
}