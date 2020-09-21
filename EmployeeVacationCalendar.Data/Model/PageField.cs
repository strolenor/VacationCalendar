using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Model
{
    public class PageField
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DefaultValue { get; set; }

        public Guid TeplateId { get; set; }

        public PageTemplate Teplate { get; set; }
    }
}
