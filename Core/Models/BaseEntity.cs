using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool Status { get; set; }
        public Nullable<DateTime> Created_at { get; set; }
        public Nullable<DateTime> Updated_at { get; set; }
        public string Create_by { get; set; }
        public string Update_by { get; set; }
    }
}
