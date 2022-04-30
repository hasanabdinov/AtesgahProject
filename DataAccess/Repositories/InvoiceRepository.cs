using Core.Dtos;
using Core.Models;
using Core.Repositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DataAccess.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private DataContext _context => Context as DataContext;
        public InvoiceRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Invoice>> GetCalculatedInvoices(CalculateDto calculateDto)
        {

            List<Invoice> invoices = new List<Invoice>();

            for (int i = 1; i <= calculateDto.LoanPeriod; i++)
            {
                Invoice invoice = new Invoice
                {
                    Amount = await StoreProcedureCalc(calculateDto.LoanPeriod, calculateDto.LoanAmount, i, calculateDto.InterestRate),
                    DueDate = calculateDto.PayoutDate.AddMonths(i).Date,
                    InvoiceNr = _context.Invoices.Count() + i,
                    OrderNr = i
                };
                invoices.Add(invoice);
            }

            var result = invoices.OrderBy(x => x.OrderNr);

            return result;
        }


        public async Task<decimal> StoreProcedureCalc(int period, decimal amount, int orderNumber, decimal percentageAsDecimal)
        {
            percentageAsDecimal = percentageAsDecimal / 100;
            var parameterReturn = new SqlParameter
            {
                ParameterName = "ReturnValue",
                SqlDbType =SqlDbType.Decimal,
                Direction =ParameterDirection.Output,
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync($"EXEC @returnValue = [dbo].[CalculateInvoice] @LoanPeriod={period}, @LoanAmount={amount}, @InvoiceOrderNr={orderNumber}, @InterestRate={percentageAsDecimal}", parameterReturn);
                decimal returnValue = (decimal)parameterReturn.Value;
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex messaje => ", ex.Message);
                throw;
            }
            
        }



    }
}
