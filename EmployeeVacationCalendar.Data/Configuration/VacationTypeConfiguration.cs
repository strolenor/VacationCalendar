using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Configuration
{
    public class VacationTypeConfiguration : IEntityTypeConfiguration<VacationType>
    {
        public void Configure(EntityTypeBuilder<VacationType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
