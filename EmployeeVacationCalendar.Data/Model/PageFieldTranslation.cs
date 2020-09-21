using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Model
{
    public class PageFieldTranslation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public Guid FieldId { get; set; }

        public PageField Field { get; set; }

        public Guid TeplateIdId { get; set; }

        public PageTemplate Template { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }
    }
}
