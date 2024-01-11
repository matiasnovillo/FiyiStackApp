using static FiyiStack.Library.NET.Structures.Tree.Utilities;

namespace FiyiStack.Library.NET.Structures.Tree
{
    public class Tree
    {
        public Node RootNode { get; set; }
        /// <summary>
        /// This field was tested to see if 100 is the capacity of tree but instead of 100, we put 1 and <br />
        /// anyway, accepted more than 1.
        /// </summary>
        private Node[] Nodes = new Node[100];
        private List<int?> List = new List<int?>();
        private int i;

        public void Add(Node NewNode)
        {
            NewNode.LeftNode = null;
            NewNode.RightNode = null;

            if (RootNode == null) { RootNode = NewNode; }
            else
            {
                Node AuxRootNode = RootNode;
                Node AuxNode = RootNode;

                while (AuxNode != null)
                {
                    AuxRootNode = AuxNode;

                    if (NewNode.NodeId < AuxNode.NodeId) { AuxNode = AuxNode.LeftNode; }
                    else { AuxNode = AuxNode.RightNode; }
                }

                if (NewNode.NodeId < AuxRootNode.NodeId) { AuxRootNode.LeftNode = NewNode; }
                else { AuxRootNode.RightNode = NewNode; }
            }
        }

        public void Balance()
        {
            try
            {
                i = 0;
                SaveVector(RootNode);
                RootNode = null;
                Balance(0, i - 1);
            }
            catch (Exception ex) { throw ex; }
        }

        public void Remove(int NodeId)
        {
            try
            {
                i = 0;
                SaveVector(RootNode, NodeId);
                RootNode = null;
                Balance(0, i - 1);
            }
            catch (Exception ex) { throw ex; }
        }

        public Node SearchNode(int NodeId)
        {
            try
            {
                Node AuxNode = RootNode;
                while (AuxNode != null)
                {
                    if (NodeId == AuxNode.NodeId) { break; }
                    else if (NodeId < AuxNode.NodeId) { AuxNode = AuxNode.LeftNode; }
                    else { AuxNode = AuxNode.RightNode; }
                }
                return AuxNode;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<int?> ToList(EListMode EListMode)
        {
            List.Clear();

            switch (EListMode)
            {
                case EListMode.InOrder:
                    InOrder(List, RootNode);
                    break;
                case EListMode.PreOrder:
                    PreOrder(List, RootNode);
                    break;
                case EListMode.PostOrder:
                    PostOrder(List, RootNode);
                    break;
                default:
                    throw new Exception("There is no listing mode defined");
            }

            return List;
        }

        private void InOrder(List<int?> temporalList, Node RootNode)
        {
            try
            {
                if (RootNode != null)
                {
                    if (RootNode.LeftNode != null) { InOrder(temporalList, RootNode.LeftNode); }

                    temporalList.Add(RootNode.NodeId);

                    if (RootNode.RightNode != null) { InOrder(temporalList, RootNode.RightNode); }
                }
                else { temporalList.Add(null); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void PreOrder(List<int?> temporalList, Node RootNode)
        {
            try
            {
                if (RootNode != null)
                {
                    temporalList.Add(RootNode.NodeId);

                    if (RootNode.LeftNode != null) { PreOrder(temporalList, RootNode.LeftNode); }

                    if (RootNode.RightNode != null) { PreOrder(temporalList, RootNode.RightNode); }
                }
                else { temporalList.Add(null); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void PostOrder(List<int?> temporalList, Node RootNode)
        {
            try
            {
                if (RootNode != null)
                {
                    if (RootNode.LeftNode != null) { PostOrder(temporalList, RootNode.LeftNode); }
                    if (RootNode.RightNode != null) { PostOrder(temporalList, RootNode.RightNode); }

                    temporalList.Add(RootNode.NodeId);
                }
                else { temporalList.Add(null); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Balance(int Start, int End)
        {
            int Middle = (Start + End) / 2;
            if (Start <= End)
            {
                Add(Nodes[Middle]);
                Balance(Start, Middle - 1);
                Balance(Middle + 1, End);
            }
        }

        private void SaveVector(Node RootNode)
        {
            try
            {
                if (RootNode.LeftNode != null) { SaveVector(RootNode.LeftNode); }

                Nodes[i] = RootNode;
                i += 1;

                if (RootNode.RightNode != null) { SaveVector(RootNode.RightNode); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void SaveVector(Node RootNode, int NodeId)
        {
            try
            {
                if (RootNode.LeftNode != null) { SaveVector(RootNode.LeftNode, NodeId); }

                if (RootNode.NodeId != NodeId)
                {
                    Nodes[i] = RootNode;
                    i += 1;
                }

                if (RootNode.RightNode != null) { SaveVector(RootNode.RightNode, NodeId); }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
