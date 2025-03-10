using FluentValidation;
using FluentValidation.Validators;


namespace Carebook.Business.ValidationRules
{
    internal class CustomDateFormatValidator<T> : PropertyValidator<T, DateTime>
    {
        private readonly string _dateFormat;
        public CustomDateFormatValidator(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override bool IsValid(ValidationContext<T> context, DateTime value)
        {
            return value != default;
        }

        public override string Name => "CustomDateFormatValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"The date format must be {_dateFormat}.";
        }
    }
    }

