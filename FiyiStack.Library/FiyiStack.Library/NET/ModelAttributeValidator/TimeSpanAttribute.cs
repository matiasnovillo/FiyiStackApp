using System.ComponentModel.DataAnnotations;

namespace FiyiStack.Library.NET.ModelAttributeValidator
{
    public class TimeSpanAttribute : ValidationAttribute
    {
        private string _PropertyName;
        private TimeSpan _MinimumTimeSpan;
        private TimeSpan _MaximumTimeSpan;
        private bool _Required;
        public TimeSpanAttribute(string PropertyName, bool Required, string TimeSpanMin = "0:00:00.000", string TimeSpanMax = "23:59:59.999")
        {
            try
            {
                if (PropertyName == null)
                { throw new Exception("The property name is empty"); }
                if (PropertyName.Length < 0)
                { throw new Exception($"The length of property name must be equal or greater than 0"); }
                if (PropertyName.Length > int.MaxValue)
                { throw new Exception($"The length of property name must be equal or less than int.MaxValue"); }

                _PropertyName = PropertyName;

                if (TimeSpanMin == null)
                { throw new Exception("The minimum TimeSpan validator is empty"); }
                if (TimeSpanMax == null)
                { throw new Exception("The maximum TimeSpan validator is empty"); }

                _MinimumTimeSpan = TimeSpan.Parse(TimeSpanMin);
                _MaximumTimeSpan = TimeSpan.Parse(TimeSpanMax);

                _Required = Required;
            }
            catch (Exception) { throw; }
        }

        public override bool IsValid(object? objTimeSpan)
        {
            try
            {
                if (_Required)
                {
                    if (objTimeSpan == null) { throw new Exception($"{_PropertyName} is empty"); }
                }

                if ((TimeSpan)objTimeSpan < _MinimumTimeSpan || (TimeSpan)objTimeSpan > _MaximumTimeSpan)
                {
                    throw new Exception($"{_PropertyName} must be inside {_MinimumTimeSpan} and {_MaximumTimeSpan}");
                }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
