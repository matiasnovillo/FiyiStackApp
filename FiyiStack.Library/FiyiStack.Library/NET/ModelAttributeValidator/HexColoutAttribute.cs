using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class HexColourAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private string _MinimumHexColourInStringFormat;
        private string _MaximumHexColourInStringFormat;
        private bool _Required;
        public HexColourAttribute(string PropertyName, bool Required, string HexColourMinInStringFormat = "000000", string HexColourMaxInStringFormat = "FFFFFF")
        {
            if (PropertyName == null) { throw new Exception("The property name is empty"); }
            if (PropertyName.Length < 0) { throw new Exception($"The length of property name must be equal or greater than 0"); }
            if (PropertyName.Length > int.MaxValue) { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

            _PropertyName = PropertyName;

            if (Validator.IsHexColour(HexColourMinInStringFormat) == false)
            {
                throw new Exception($"{HexColourMinInStringFormat} is not a valid Hex colour");
            }
            if (Validator.IsHexColour(HexColourMaxInStringFormat) == false)
            {
                throw new Exception($"{HexColourMaxInStringFormat} is not a valid Hex colour");
            }
            _MinimumHexColourInStringFormat = HexColourMinInStringFormat;
            _MaximumHexColourInStringFormat = HexColourMaxInStringFormat;

            _Required = Required;
        }

        public override bool IsValid(object? objHexColourInStringFormat)
        {
            try
            {
                if (_Required)
                {
                    if (objHexColourInStringFormat == null)
                    { throw new Exception($"{_PropertyName} is empty"); }
                }
                if (Validator.IsHexColour(objHexColourInStringFormat.ToString()) == false)
                { throw new Exception($"{_PropertyName} is not a valid Hex colour"); }
                if (Validator.CompareStrings(objHexColourInStringFormat.ToString(), _MinimumHexColourInStringFormat) == 'B')
                { throw new Exception($"{_PropertyName} is less than {_MinimumHexColourInStringFormat}"); }
                if (Validator.CompareStrings(objHexColourInStringFormat.ToString(), _MaximumHexColourInStringFormat) == 'A')
                { throw new Exception($"{_PropertyName} is greater than {_MaximumHexColourInStringFormat}"); }

                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
