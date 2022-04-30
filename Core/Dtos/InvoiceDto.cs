using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class InvoiceDto
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public CalculateDto CalculateDto { get; set; }
        public decimal TotalInterest { get; set; }
    }
}
