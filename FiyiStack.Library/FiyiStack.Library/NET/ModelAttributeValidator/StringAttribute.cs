using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class StringAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private int _MinimumLength;
        private int _MaximumLength;
        private string _RegexString;
        private bool _Required;
        public StringAttribute(string PropertyName, bool Required, int MinimumLength = 0, int MaximumLength = int.MaxValue, string RegexString = "")
        {
            try
            {
                if (PropertyName == null) { throw new Exception("The property name is empty"); }
                if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
                if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

                _PropertyName = PropertyName;

                if (MinimumLength < 0)
                {
                    throw new Exception("Minimum length for a string must be equal or better than 0");
                }
                if (MaximumLength > int.MaxValue)
                {
                    throw new Exception("Maximum length for a string must be equal or less than int.MaxValue");
                }

                _MinimumLength = MinimumLength;
                _MaximumLength = MaximumLength;
                _RegexString = RegexString;

                _Required = Required;
            }
            catch (Exception) { throw; }
        }
        public override bool IsValid(object? objString)
        {
            try
            {
                if (_Required)
                {
                    if (objString == null) { throw new Exception($"{_PropertyName} is empty"); }
                }

                if (objString.ToString().Length < _MinimumLength)
                {
                    throw new Exception($"{_PropertyName} " +
                        $"{(objString.ToString().Length > 5 ? objString.ToString().Substring(0, 5) + "..." : objString.ToString())} " +
                        $"has a length less than the required");
                }
                if (objString.ToString().Length > _MaximumLength)
                {
                    throw new Exception($"{_PropertyName} " +
                        $"{(objString.ToString().Length > 5 ? objString.ToString().Substring(0, 5) + "..." : objString.ToString())} " +
                        $"has a length greater than the required");
                }
                if (_RegexString != "")
                {
                    if (Validator.IsRegexOk(objString.ToString(), _RegexString) == false)
                    {
                        throw new Exception($"{_PropertyName} " +
                        $"{(objString.ToString().Length > 5 ? objString.ToString().Substring(0, 5) + "..." : objString.ToString())} " +
                        $"did not pass the Regex test");
                    }
                }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
