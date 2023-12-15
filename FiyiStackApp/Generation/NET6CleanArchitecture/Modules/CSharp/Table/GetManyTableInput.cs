﻿using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string GetManyTableInput(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Shared.Core.Enum;

namespace {Table.Name}.Input;
public class GetMany{Table.Name}Input
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
