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
            RuleFor(a => a.ClientID).NotEqual(0).NotNull().WithMessage("ClientID cannot be empty");
            RuleFor(a => a.TelephoneNr).NotNull().WithMessage("TelephoneNr cannot be empty").NotEmpty().WithMessage("TelephoneNr cannot be empty");
            RuleFor(a => a.LoanAmount).NotEmpty().WithMessage("LoanAmount cannot be empty").NotNull().WithMessage("LoanAmount cannot be empty");

            RuleFor(a => a.LoanPeriod).NotEmpty().WithMessage("LoanPeriod cannot be empty").NotNull().WithMessage("LoanPeriod cannot be empty");
            RuleFor(a => a.InterestRate).NotEmpty().WithMessage("InterestRate cannot be empty").NotNull().WithMessage("InterestRate cannot be empty");
            RuleFor(a => a.PayoutDate).NotEmpty().WithMessage("PayoutDate cannot be empty").NotNull().WithMessage("PayoutDate cannot be empty");

            RuleFor(a => a).Custom((model, context) =>
            {
                if (model.LoanAmount<= 100 && model.LoanAmount >= 5000 )
                {
                    context.AddFailure("You can give Loan Amount 100 to 5000 only!");
                }

                if(model.InterestRate < 0)
                {
                    context.AddFailure("The percentage must be greater than 0!");
                }
            });
        }
    }
}
