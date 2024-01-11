namespace FiyiStack.Library.NET.Structures.Graph
{
    public class Node
    {
        private Node RootNode { get; set; }
        private Node LeftNode { get; set; }
        private Node RightNode { get; set; }
        public string NodeName { get; set; }
        public NodeList NodeList { get; set; }

        public void Add(Node NewNode)
        {
            try
            {
                NewNode.LeftNode = null;
                NewNode.RightNode = null;

                if (RootNode == null)
                    RootNode = NewNode;
                else
                {
                    Node AuxRootNode1 = RootNode;
                    Node AuxRootNode2 = RootNode;

                    while (AuxRootNode2 != null)
                    {
                        AuxRootNode1 = AuxRootNode2;

                        if (Validator.CompareStrings(NewNode.NodeName, AuxRootNode2.NodeName) == 'B')
                        { AuxRootNode2 = AuxRootNode2.LeftNode; }
                        else
                        { AuxRootNode2 = AuxRootNode2.RightNode; }
                    }

                    if (Validator.CompareStrings(NewNode.NodeName, AuxRootNode1.NodeName) == 'B')
                    { AuxRootNode1.LeftNode = NewNode; }
                    else
                    { AuxRootNode1.RightNode = NewNode; }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<string> ToDataTable()
        {
            try
            {
                List<string> List = new List<string>();

                List.Add("NodeName");

                if (RootNode != null) { InOrder(List, RootNode); }

                return List;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Balance()
        {
            try
            {
                int i = 0;
                SaveNodes(RootNode);
                RootNode = null;
                Balance(0, i - 1);
            }
            catch (Exception) { throw; }
        }

        private void Balance(int Start, int End)
        {
            try
            {
                int Middle = (Start + End) / 2;
                if (Start <= End)
                {
                    Add(Utilities.Nodes[Middle]);
                    Balance(Start, Middle - 1);
                    Balance(Middle + 1, End);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void InOrder(List<string> List, Node NodeFather)
        {
            try
            {
                if (NodeFather.LeftNode != null) { InOrder(List, NodeFather.LeftNode); }

                List.Add(NodeFather.NodeName);

                if (NodeFather.RightNode != null) { InOrder(List, NodeFather.RightNode); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void SaveNodes(Node NodeFather)
        {
            if (NodeFather.LeftNode != null) { SaveNodes(NodeFather.LeftNode); }

            Utilities.Nodes[Utilities.i] = NodeFather;
            Utilities.i += 1;

            if (NodeFather.RightNode != null) { SaveNodes(NodeFather.RightNode); }
        }

        public Node Peek(string SearchString)
        {
            try
            {
                Node Aux = RootNode;

                while (Aux != null)
                {
                    if (SearchString == Aux.NodeName)
                        break;
                    else if (Validator.CompareStrings(SearchString, Aux.NodeName) == 'B')
                        Aux = Aux.LeftNode;
                    else
                        Aux = Aux.RightNode;
                }
                return Aux;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Search(string SearchString)
        {
            try
            {
                bool Exist = false;

                Node Aux = RootNode;

                while (Aux != null)
                {
                    if (SearchString == Aux.NodeName)
                    {
                        Exist = true;
                        break;
                    }
                    else if (Validator.CompareStrings(SearchString, Aux.NodeName) == 'B') { Aux = Aux.LeftNode; }
                    else { Aux = Aux.RightNode; }
                }

                return Exist;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
