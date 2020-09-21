using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeVacationCalendar.Data.Configuration
{
    public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.VacationType).WithMany().HasForeignKey(y => y.VacationTypeId).IsRequired(true);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(y => y.UserId).IsRequired(true);
        }
    }
}
