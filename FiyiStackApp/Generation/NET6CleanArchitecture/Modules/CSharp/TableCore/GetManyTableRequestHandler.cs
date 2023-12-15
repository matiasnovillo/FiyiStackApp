using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string GetManyTableRequestHandler(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using {Table.Name}.Core.Abstractions;
using {Table.Name}.Core.Model;

namespace {Table.Name}.Core.Features.GetMany{Table.Name};
public class GetMany{Table.Name}RequestHandler : IRequestHandler<GetMany{Table.Name}Request, GetMany{Table.Name}Response>
{{
    private readonly I{Table.Name}Repository _{Table.Name.ToLower()}Repository;
    private readonly IMapper _mapper;

    public GetMany{Table.Name}RequestHandler(I{Table.Name}Repository {Table.Name.ToLower()}Repository, IMapper mapper)
    {{
        _{Table.Name.ToLower()}Repository = {Table.Name.ToLower()}Repository;
        _mapper = mapper;
    }}
    public async Task<GetMany{Table.Name}Response> Handle(GetMany{Table.Name}Request request, CancellationToken cancellationToken)
    {{
        throw new NotImplementedException();
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
