using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Invoice : BaseEntity
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceNr { get; set; }
        public int OrderNr { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
