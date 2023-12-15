using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string CreateTableRequestHandler(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using AutoMapper;
using MediatR;
using {Table.Name}.Core.Abstractions;
using {Table.Name}.Core.Model;
using Shared.Core.Domain;

namespace {Table.Name}.Core.Features.Create{Table.Name};
public class Create{Table.Name}RequestHandler : IRequestHandler<Create{Table.Name}Request, Create{Table.Name}Response>
{{
    private readonly I{Table.Name}Repository _{Table.Name.ToLower()}Repository;
    private readonly IMapper _mapper;

    public Create{Table.Name}RequestHandler(I{Table.Name}Repository {Table.Name.ToLower()}Repository, IMapper mapper)
    {{
        _{Table.Name.ToLower()}Repository = {Table.Name.ToLower()}Repository;
        _mapper = mapper;
    }}
    public async Task<Create{Table.Name}Response> Handle(Create{Table.Name}Request request, CancellationToken cancellationToken)
    {{
        throw new NotImplementedException();
    }}
}}

";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
