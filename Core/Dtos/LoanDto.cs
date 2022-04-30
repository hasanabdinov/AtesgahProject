using Core.Models;
using System.Collections.Generic;


namespace Core.Dtos
{
    public class LoanDto
    {
        public IEnumerable<LoanDetailDto> Loans { get; set; }
        public CalculateDto CalculateDto { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public Message ViewResult { get; set; }
        public int MinPayPeriod { get; set; }
        public int MaxPayPeriod { get; set; }
    }
}
