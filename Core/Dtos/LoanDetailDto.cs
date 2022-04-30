using System;

namespace Core.Dtos
{
    public class LoanDetailDto
    {
        public string ClientID { get; set; }
        public string ClientFullName { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime PayoutDate { get; set; }
        public int LoanID { get; set; }
    }
}