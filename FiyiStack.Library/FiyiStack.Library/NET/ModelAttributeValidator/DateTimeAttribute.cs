using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class DateTimeAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private DateTime _MinimumDateTime;
        private DateTime _MaximumDateTime;
        private bool _Required;
        public DateTimeAttribute(string PropertyName, bool Required, string DateTimeMinValue, string DateTimeMaxValue)
        {
            try
            {
                if (PropertyName == null) { throw new Exception("The property name is empty"); }
                if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
                if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

                _PropertyName = PropertyName;

                if (DateTimeMinValue == null) { throw new Exception("The minimum DateTime validator is empty"); }
                if (DateTimeMaxValue == null) { throw new Exception("The maximum DateTime validator is empty"); }

                _MinimumDateTime = System.Convert.ToDateTime(DateTimeMinValue);
                _MaximumDateTime = System.Convert.ToDateTime(DateTimeMaxValue);

                _Required = Required;
            }
            catch (Exception) { throw; }
        }

        public override bool IsValid(object? objDateTime)
        {
            try
            {
                if (_Required)
                {
                    if (objDateTime == null) { throw new Exception($"{_PropertyName} is empty"); }
                }

                if ((DateTime)objDateTime < _MinimumDateTime || (DateTime)objDateTime > _MaximumDateTime)
                {
                    throw new Exception($"{_PropertyName} must be inside {_MinimumDateTime} and {_MaximumDateTime}");
                }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
