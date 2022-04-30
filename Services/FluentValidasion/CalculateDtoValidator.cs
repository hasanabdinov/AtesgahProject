using Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.FluentValidasion
{
    public class CalculateDtoValidator : AbstractValidator<CalculateDto>
    {
        public CalculateDtoValidator()
        {
            RuleFor(a => a.ClientID).NotEqual(0).NotNull().WithMessage("ClientID boş ola bilməz");
            RuleFor(a => a.TelephoneNr).NotNull().WithMessage("TelephoneNr boş ola bilməz").NotEmpty().WithMessage("TelephoneNr bos ola bilmez");
            RuleFor(a => a.LoanAmount).NotEmpty().WithMessage("LoanAmount boş ola bilməz").NotNull().WithMessage("LoanAmount boş ola bilməz");

            RuleFor(a => a.LoanPeriod).NotEmpty().WithMessage("LoanPeriod boş ola bilməz").NotNull().WithMessage("LoanPeriod boş ola bilməz");
            RuleFor(a => a.InterestRate).NotEmpty().WithMessage("InterestRate boş ola bilməz").NotNull().WithMessage("InterestRate boş ola bilməz");
            RuleFor(a => a.PayoutDate).NotEmpty().WithMessage("PayoutDate boş ola bilməz").NotNull().WithMessage("PayoutDate boş ola bilməz");

            RuleFor(a => a).Custom((model, context) =>
            {
                if (model.LoanAmount<= 100 && model.LoanAmount >= 5000 )
                {
                    context.AddFailure("LoanAmount 100-den boyuk 5000-den kicik olmalidi deyeri");
                }

                if(model.InterestRate < 0)
                {
                    context.AddFailure("Faiz 0-dan boyuk olmalidi..");

                }
            });
        }
    }
}
