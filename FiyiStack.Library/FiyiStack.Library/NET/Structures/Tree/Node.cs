namespace FiyiStack.Library.NET.Structures.Tree
{
    public class Node
    {
        //Minimum properties to run
        public Node RightNode { get; set; }
        public Node LeftNode { get; set; }
        public int NodeId { get; set; }

        //Add-ons for Node
        public string Data1 { get; set; }
        public int Data2 { get; set; }
    }
}
