using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Loan:BaseEntity
    {
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual IEnumerable<Invoice> Invoices { get; set; }
    }
}
