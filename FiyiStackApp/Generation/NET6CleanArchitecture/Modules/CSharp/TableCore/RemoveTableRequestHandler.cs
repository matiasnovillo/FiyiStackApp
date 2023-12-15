using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string RemoveTableRequestHandler(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using AutoMapper;
using MediatR;
using {Table.Name}.Core.Abstractions;
using {Table.Name}.Core.Model;

namespace {Table.Name}.Core.Features.Remove{Table.Name};
public class Remove{Table.Name}RequestHandler : IRequestHandler<Remove{Table.Name}Request, Remove{Table.Name}Response>
{{
    private readonly I{Table.Name}Repository _{Table.Name.ToLower()}Repository;
    private readonly IMapper _mapper;

    public Remove{Table.Name}RequestHandler(I{Table.Name}Repository {Table.Name.ToLower()}Repository, IMapper mapper)
    {{
        _{Table.Name.ToLower()}Repository = {Table.Name.ToLower()}Repository;
        _mapper = mapper;
    }}
    public async Task<Remove{Table.Name}Response> Handle(Remove{Table.Name}Request request, CancellationToken cancellationToken)
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
