using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Configuration
{
    class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Country).WithMany().HasForeignKey(y => y.CountryId).IsRequired(true);
        }
    }
}
