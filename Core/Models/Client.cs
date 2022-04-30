using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Client : BaseEntity
    {
        public string ClientUniqueID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNr { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}
