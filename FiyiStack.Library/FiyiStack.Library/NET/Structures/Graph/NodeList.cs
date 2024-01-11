using System.Data;

namespace FiyiStack.Library.NET.Structures.Graph
{
    public class NodeList
    {
        //Minimum properties to run
        private NodeList? NextNodeList { get; set; }
        private NodeList? FirstNodeList { get; set; }

        //Add-ons for NodeList
        public string? Data1 { get; set; }
        public int Data2 { get; set; }
        public decimal Data3 { get; set; }

        public void Add(NodeList NewNodeList)
        {
            try
            {
                if (FirstNodeList == null) { FirstNodeList = NewNodeList; }
                else if (Validator.CompareStrings(NewNodeList.Data1, FirstNodeList.Data1) == 'B')
                {
                    NewNodeList.NextNodeList = FirstNodeList;
                    FirstNodeList = NewNodeList;
                }
                else
                {
                    var AuxFirstNodeList = FirstNodeList;

                    if (AuxFirstNodeList.NextNodeList != null)
                    {
                        while (Validator.CompareStrings
                            (AuxFirstNodeList.NextNodeList.Data1, NewNodeList.Data1) == 'B')
                        {
                            AuxFirstNodeList = AuxFirstNodeList.NextNodeList;

                            if (AuxFirstNodeList.NextNodeList == null) { break; }
                        }
                    }
                    NewNodeList.NextNodeList = AuxFirstNodeList.NextNodeList;

                    AuxFirstNodeList.NextNodeList = NewNodeList;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable ToDataTable()
        {
            try
            {
                DataTable DataTable = new DataTable();
                DataTable.Columns.Add("Data1", typeof(string));
                DataTable.Columns.Add("Data2", typeof(int));
                DataTable.Columns.Add("Data3", typeof(decimal));
                NodeList AuxFirstNodeList = FirstNodeList;

                while (AuxFirstNodeList != null)
                {
                    DataTable.Rows.Add(AuxFirstNodeList.Data1, AuxFirstNodeList.Data2, AuxFirstNodeList.Data3);
                    AuxFirstNodeList = AuxFirstNodeList.NextNodeList;
                }
                return DataTable;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
