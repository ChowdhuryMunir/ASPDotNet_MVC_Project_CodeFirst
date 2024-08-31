using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectImplementationOfMasterDetails.Models.ViewModels
{
    public class DetailsVM
    {
        //Employee-Master 
        public string EmployeeName { get; set; }
        public DateTime PayDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Image { get; set; }

        //AllowenceDetails

        public int DetailsId { get; set; }
        public int EmployeeId { get; set; }
        public int AllowanceTypeId { get; set; }

        public int Amount { get; set; }

        //CheckBox For agree

        public bool Terms { get; set; }
    }
}