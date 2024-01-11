using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class DecimalAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private decimal _MinimumDecimalNumber;
        private decimal _MaximumDecimalNumber;
        private bool _Required;
        public DecimalAttribute(string PropertyName, bool Required, double DecimalMin = (double)decimal.MinValue, double DecimalMax = (double)decimal.MaxValue)
        {
            try
            {
                if (PropertyName == null) { throw new Exception("The property name is empty"); }
                if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
                if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

                _PropertyName = PropertyName;

                if (DecimalMin < (double)decimal.MinValue || DecimalMin > (double)decimal.MaxValue)
                {
                    throw new Exception("The validator MinimumDecimalNumber must be inside decimalDBMin and decimalDBMax");
                }
                if (DecimalMax < (double)decimal.MinValue || DecimalMax > (double)decimal.MaxValue)
                {
                    throw new Exception("The validator MaximumDecimalNumber must be inside decimalDBMin and decimalDBMax");
                }
                _MinimumDecimalNumber = (decimal)DecimalMin;
                _MaximumDecimalNumber = (decimal)DecimalMax;

                _Required = Required;
            }
            catch (Exception) { throw; }
        }

        public override bool IsValid(object? objDecimal)
        {
            try
            {
                if (_Required)
                {
                    if (objDecimal == null) { throw new Exception($"{_PropertyName} is empty"); }
                }
                if (objDecimal.GetType() != typeof(decimal)) { throw new Exception($"{_PropertyName} is not a valid decimal number"); }

                if ((decimal)objDecimal < decimal.MinValue || (decimal)objDecimal > decimal.MaxValue)
                {
                    throw new Exception($"{_PropertyName} must be inside decimalDBMin and decimalDBMax");
                }
                if ((decimal)objDecimal < _MinimumDecimalNumber || (decimal)objDecimal > _MaximumDecimalNumber)
                {
                    throw new Exception($"{_PropertyName} must be inside {_MinimumDecimalNumber} and {_MaximumDecimalNumber}");
                }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
