using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class RequiredAttribute : ValidationAttribute
    {
        private string _PropertyName;
        public RequiredAttribute(string PropertyName)
        {
            if (PropertyName == null) { throw new Exception("The property name is empty"); }
            if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
            if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

            _PropertyName = PropertyName;
        }

        public override bool IsValid(object? obj)
        {
            try
            {
                if (obj == null)
                { throw new Exception($"{_PropertyName} is empty"); }

                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
