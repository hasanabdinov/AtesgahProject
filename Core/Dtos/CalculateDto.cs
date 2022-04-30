using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class CalculateDto
    {
        public int ClientID { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
        public string TelephoneNr { get; set; }
        public virtual IEnumerable<Invoice> Invoices { get; set; }

    }
}