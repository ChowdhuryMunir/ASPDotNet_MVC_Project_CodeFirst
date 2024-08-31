using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectImplementationOfMasterDetails.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }


        public DateTimeOffset PayDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Details> Details { get; set; }

    }
}