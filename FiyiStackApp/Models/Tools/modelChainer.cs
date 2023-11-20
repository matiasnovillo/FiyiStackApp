using FiyiStackApp.Models.Core;
using System;
using System.Collections.Generic;

namespace FiyiStackApp.Models.Tools
{
    public class modelChainer
    {
        public int CounterOfModelsThatDependOnThis { get; set; } = 0;

        public string CSharpModelsThatDependOnThis_ForCSharpModel { get; set; } = "";

        public string NewList_ForCSharpModel { get; set; } = "";

        public string LoopThroughListsAndSubLists_ForCSharpModel { get; set; } = "";

        public string NewList_ForTypeScriptModel { get; set; } = "";

        public string Imports_ForTypeScriptModel { get; set; } = "";
        public modelChainer()
        {
        }
        /// <summary>
        /// To understand this constructor, I used Blog and CommentForBlog, where
        /// CommentForBlog is a sub-model of Blog
        /// </summary>
        /// <param name="Blog"></param>
        /// <param name="lstAllTables"></param>

        public modelChainer(Table Blog, List<Table> lstAllTables)
        {
            List<Field> lstTablesFiltered = new List<Field>();

            foreach (Table iTable in lstAllTables)
            {
                List<Field> ilstField = new Field().GetAllByTableIdByForeignTableNameToModel(iTable.TableId, Blog.Name);
                foreach (Field iField in ilstField)
                { lstTablesFiltered.Add(iField); }
            }

            foreach (Field CommentForBlogId in lstTablesFiltered)
            {
                Table CommentForBlog = new Table(CommentForBlogId.TableId);

                CSharpModelsThatDependOnThis_ForCSharpModel += $"public virtual List<{CommentForBlog.Name}Model> lst{CommentForBlog.Name}Model {{ get; set; }} //Foreign Key name: {CommentForBlogId.Name} {Environment.NewLine}" + "\t\t";

                CounterOfModelsThatDependOnThis += 1;

                NewList_ForCSharpModel += $@"lst{CommentForBlog.Name}Model = new List<{CommentForBlog.Name}Model>();
                ";

                LoopThroughListsAndSubLists_ForCSharpModel += $@"//Loop through lists and sublists
                for (int i = 0; i < {Blog.Name.ToLower()}SelectAllPaged.lst{Blog.Name}Model.Count; i++)
                {{
                    DynamicParameters dpFor{CommentForBlog.Name}Model = new DynamicParameters();
                    dpFor{CommentForBlog.Name}Model.Add(""{Blog.Name}Id"", {Blog.Name.ToLower()}SelectAllPaged.lst{Blog.Name}Model[i].{Blog.Name}Id, DbType.Int32, ParameterDirection.Input);
                    using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                    {{
                        List<{CommentForBlog.Name}Model> lst{CommentForBlog.Name}Model = new List<{CommentForBlog.Name}Model>();
                        lst{CommentForBlog.Name}Model = (List<{CommentForBlog.Name}Model>)sqlConnection.Query<{CommentForBlog.Name}Model>(""[{CommentForBlog.Scheme}].[{CommentForBlog.Area}.{CommentForBlog.Name}.SelectAllBy{Blog.Name}IdCustom]"", dpFor{CommentForBlog.Name}Model, commandType: CommandType.StoredProcedure);
                        
                        //Add list item inside another list
                        foreach (var {CommentForBlog.Name}Model in lst{CommentForBlog.Name}Model)
                        {{
                            {Blog.Name.ToLower()}SelectAllPaged.lst{Blog.Name}Model[i].lst{CommentForBlog.Name}Model.Add({CommentForBlog.Name}Model);
                        }}
                    }}
                }}
                
                ";

                NewList_ForTypeScriptModel += $@"lst{CommentForBlog.Name}Model?: {CommentForBlog.Name}Model[] | undefined;
    ";

                Imports_ForTypeScriptModel += $@"import {{ {CommentForBlog.Name}Model }} from ""../../{CommentForBlog.Name}/TsModels/{CommentForBlog.Name}_TsModel"";";
            }

            CSharpModelsThatDependOnThis_ForCSharpModel = CSharpModelsThatDependOnThis_ForCSharpModel.TrimEnd('\t', '\t', '\n', '\r');
        }
    }
}
