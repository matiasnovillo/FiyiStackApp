using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class IntAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private int _MinimumInt;
        private int _MaximumInt;
        private bool _Required;
        public IntAttribute(string PropertyName, bool Required, int IntMin = int.MinValue, int IntMax = int.MaxValue)
        {
            if (PropertyName == null) { throw new Exception("The property name is empty"); }
            if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
            if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

            _PropertyName = PropertyName;

            if (IntMin < int.MinValue || IntMin > int.MaxValue)
            {
                throw new Exception("The validator MinimumInt must be inside int.MinValue and int.MaxValue");
            }
            if (IntMax < int.MinValue || IntMax > int.MaxValue)
            {
                throw new Exception("The validator MaximumInt must be inside int.MinValue and int.MaxValue");
            }

            _MinimumInt = IntMin;
            _MaximumInt = IntMax;
            _Required = Required;
        }

        public override bool IsValid(object? objInt)
        {
            try
            {
                if (_Required)
                {
                    if (objInt == null)
                    { throw new Exception($"{_PropertyName} is empty"); }
                }
                if (Convert.ToInt32(objInt) < int.MinValue || Convert.ToInt32(objInt) > int.MaxValue)
                {
                    throw new Exception($"{_PropertyName} must be inside int.MinValue and int.MaxValue");
                }
                if (Convert.ToInt32(objInt) < _MinimumInt || Convert.ToInt32(objInt) > _MaximumInt)
                {
                    throw new Exception($"{_PropertyName} must be inside {_MinimumInt} and {_MaximumInt}");
                }

                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
