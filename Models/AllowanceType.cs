using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectImplementationOfMasterDetails.Models
{
    public class AllowanceType
    {
        public int AllowanceTypeId { get; set; }
        public string AllowanceName { get; set; }

        public AllowanceCategory AllowanceCategory { get; set; }
        public int AllowanceCategoryId { get; set; }
    }
}