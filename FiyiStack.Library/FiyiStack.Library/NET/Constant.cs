using System.Text.RegularExpressions;

namespace FiyiStack.Library.NET
{
    public static class Constant
    {
        #region Regular expressions
        /// <summary>
        /// This Regex accept letters (a to z, A to Z), numbers (0 to 9), ., _, and -
        /// </summary>
        public static Regex RegexAlphanumeric = new Regex(@"^[a-zA-Z0-9._-]+$");

        /// <summary>
        /// This Regex accept letters (a to z)
        /// </summary>
        public static Regex RegexLowerCase = new Regex(@"^[a-z]+$");

        /// <summary>
        /// This Regex accepts only numbers (0 to 9)
        /// </summary>
        public static Regex RegexOnlyNumbers = new Regex(@"^[0-9]+$"); 
        #endregion

        /// <summary>
        /// This is the FiyiStack GUID
        /// </summary>
        public static Guid FiyiStackGUID = new Guid("E6C09DFE-3A3E-461B-B3F9-734AEE05FC7B");
    }
}
