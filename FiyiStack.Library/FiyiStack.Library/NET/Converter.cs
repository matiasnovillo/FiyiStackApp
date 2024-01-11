using System.Reflection;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace FiyiStack.Library.NET
{
    public static class Converter
    {
        /// <returns>A byte array with UTF-8 encoding</returns>
        public static byte[] StringToByteArray(string String)
        {
            try
            {
                if (true)
                {
                    return Encoding.UTF8.GetBytes(String); 
                }
            }
            catch (Exception) { throw; }
        }

        /// <returns>A string with UTF-8 encoding</returns>
        public static string ByteArrayToString(byte[] ByteArray)
        {
            try
            {
                return Encoding.UTF8.GetString(ByteArray);
            }
            catch (Exception) { throw; }
        }

        /// <returns>A byte array with UTF-8 encoding</returns>
        public static byte[] IntToByteArray(int Int)
        {
            try
            {
                return Encoding.UTF8.GetBytes(Int.ToString());
            }
            catch (Exception) { throw; }
        }

        /// <returns>An int with UTF-8 encoding</returns>
        public static int ByteArrayToInt(byte[] ByteArray)
        {
            try
            {
                return Convert.ToInt32(Encoding.UTF8.GetString(ByteArray));
            }
            catch (Exception) { throw; }
        }

        [Obsolete()]
        public static byte[] ObjectToByteArray(object Object)
        {
            try
            {
                if (Object == null) { throw new Exception("Object can't be null"); }

                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream();
                BinaryFormatter.Serialize(MemoryStream, Object);
                return MemoryStream.ToArray();
            }
            catch (Exception) { throw; }
        }

        public static object CopyObjectProperties(object OriginalObject, object DestinyObject)
        {
            try
            {
                if (OriginalObject == null || DestinyObject == null) { throw new Exception("Parameters can't be null"); }

                bool HasPropertiesToCopy = false;
                PropertyInfo[] ListDestinyObjectProperties = DestinyObject.GetType().GetProperties();

                foreach (PropertyInfo destinyObjectProperty in ListDestinyObjectProperties)
                {
                    PropertyInfo? OriginalProperty = OriginalObject.GetType().GetProperty(destinyObjectProperty.Name);
                    
                    if (OriginalProperty != null)
                    {
                        if (OriginalProperty.CanWrite)
                        {
                            destinyObjectProperty.SetValue(DestinyObject, OriginalProperty.GetValue(OriginalObject, null), null);
                            HasPropertiesToCopy = true;
                        }
                    }
                }
                if (HasPropertiesToCopy)
                { return DestinyObject; }
                else
                { throw new Exception("The properties of original object are null or can't be written"); }
            }
            catch (Exception) { throw; }
        }

        public static object SetObjectPropertiesToNull(object Object)
        {
            try
            {
                bool HasPropertiesToModifiy = false;
                PropertyInfo[] ListObjectProperties = Object.GetType().GetProperties();
                foreach (PropertyInfo objectProperty in ListObjectProperties)
                {
                    if (objectProperty != null)
                    {
                        if (objectProperty.CanWrite)
                        {
                            objectProperty.SetValue(Object, null, null);
                        }                    
                    }
                }
                if (HasPropertiesToModifiy)
                { return Object; }
                else
                { throw new Exception("The properties of original object are null or can't be written"); }
            }
            catch (Exception) { throw; }
        }
    }
}
