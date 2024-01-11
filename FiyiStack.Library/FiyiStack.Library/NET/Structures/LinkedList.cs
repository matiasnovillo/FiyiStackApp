using System.Text;

namespace FiyiStack.Library.NET.Structures
{
    /// <summary>
    /// Here there is no classes to make LinkedList objects <br/>
    /// To create LinkedList objects refer to System.Collections.Generic.LinkedList<T>
    /// </summary>
    public static class LinkedList
    {
        public static List<string> ToList(LinkedList<string> LinkedListWithStringFormat)
        {
            try
            {
                List<string> ListInStringFormat = new List<string>();
                foreach (string Node in LinkedListWithStringFormat)
                {
                    ListInStringFormat.Add(Node);
                }
                return ListInStringFormat;
            }
            catch (Exception ex) { throw ex; }

        }

        public static string[] ToStringArray(LinkedList<string> LinkedListWithStringFormat, int StringArrayIndexToStart = 0)
        {
            try
            {
                string[] StringArray = new string[LinkedListWithStringFormat.Count];

                LinkedListWithStringFormat.CopyTo(StringArray, StringArrayIndexToStart);

                return StringArray;
            }
            catch (Exception ex) { throw ex; }
        }

        public static string HighLightNode(LinkedListNode<string> LinkedListNode, string HighLightIndicator)
        {
            try
            {
                if (LinkedListNode.List == null)
                {
                    throw new Exception($"Node {LinkedListNode.Value} is not in the list");
                }

                StringBuilder LinkedListToString = new StringBuilder(HighLightIndicator + LinkedListNode.Value + HighLightIndicator);
                LinkedListNode<string> PreviousNode = LinkedListNode.Previous;

                while (PreviousNode != null)
                {
                    LinkedListToString.Insert(0, PreviousNode.Value + " ");
                    PreviousNode = PreviousNode.Previous;
                }

                LinkedListNode = LinkedListNode.Next;
                while (LinkedListNode != null)
                {
                    LinkedListToString.Append(" " + LinkedListNode.Value);
                    LinkedListNode = LinkedListNode.Next;
                }

                return LinkedListToString.ToString();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
