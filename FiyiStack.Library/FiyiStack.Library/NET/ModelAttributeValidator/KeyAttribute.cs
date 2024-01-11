using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class KeyAttribute : ValidationAttribute
    {
        private string _PropertyName;
        public KeyAttribute(string PropertyName)
        {
            try
            {
                if (PropertyName == null) { throw new Exception("The property name is empty"); }
                if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
                if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

                _PropertyName = PropertyName;
            }
            catch (Exception) { throw; }
        }

        public override bool IsValid(object? objPrimaryKey)
        {
            try
            {
                if (objPrimaryKey == null) { throw new Exception($"{_PropertyName} not found"); }
                if (Convert.ToInt32(objPrimaryKey) < 0) { throw new Exception($"{_PropertyName} must be equal or better than 0"); }
                if (Convert.ToInt32(objPrimaryKey) > int.MaxValue) { throw new Exception($"{_PropertyName} must be equal or less than int.MaxValue"); }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
