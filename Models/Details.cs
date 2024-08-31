using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectImplementationOfMasterDetails.Models
{
    public class Details
    {
        public int DetailsId { get; set; }
        public int EmployeeId { get; set; }
        public int AllowanceTypeId { get; set; }

        public int Amount { get; set; }

        public Employee Employee { get; set; }
        public AllowanceType AllowanceType { get; set; }

    }
}