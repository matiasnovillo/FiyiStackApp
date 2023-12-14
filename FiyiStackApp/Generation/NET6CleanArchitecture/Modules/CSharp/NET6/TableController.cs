using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string TableController(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using {Table.Name}.Core.Features.Create{Table.Name};
using {Table.Name}.Core.Features.GetMany{Table.Name};
using {Table.Name}.Core.Features.GetOne{Table.Name};
using {Table.Name}.Core.Features.Remove{Table.Name};
using {Table.Name}.Core.Features.Restore{Table.Name};
using {Table.Name}.Core.Features.Update{Table.Name};
using {Table.Name}.Core.Model;
using {Table.Name}.Input;
using Shared.Core.Enum;
using Shared.Infrastructure.Extensions;

namespace {Table.Name}.Controllers;

[Route(""api/{Table.Name.ToLower()}"")]
[ApiController]
[Authorize]
public class {Table.Name}Controller : ControllerBase
{{
    public readonly IMediator _mediator;
    public {Table.Name}Controller(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Gets a {Table.Name.ToLower()} with all it's relationships
    /// </summary>
    [HttpGet(""{{{Table.Name.ToLower()}Id}}"")]
    public async Task<{Table.Name}Model> FindOne(int {Table.Name.ToLower()}Id, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new GetOne{Table.Name}Request
        {{
            {Table.Name}Id = {Table.Name.ToLower()}Id,
        }}, cancellationToken);

        return response.{Table.Name};
    }}

    /// <summary>
    /// Finds all {Table.Name.ToLower()} that match a given criteria
    /// </summary>
    [HttpGet]
    public async Task<ICollection<{Table.Name}Model>> FindMany([FromQuery] GetMany{Table.Name}Input input, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new GetMany{Table.Name}Request
        {{
            //TODO
        }}, cancellationToken);

        return response.{Table.Name};
    }}

    /// <summary>
    /// Creates a new {Table.Name.ToLower()}
    /// </summary>
    [HttpPost]
    public async Task<{Table.Name}Model> Create(Create{Table.Name}Input input, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new Create{Table.Name}Request
        {{
            //TODO
        }}, cancellationToken);

        return response.{Table.Name};
    }}

    /// <summary>
    /// Updates a {Table.Name.ToLower()}
    /// </summary>
    [HttpPut(""{{{Table.Name.ToLower()}Id}}"")]
    public async Task<{Table.Name}Model> Update(int {Table.Name.ToLower()}Id, Update{Table.Name}Input input, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new Update{Table.Name}Request
        {{
            //TODO
        }}, cancellationToken);

        return response.{Table.Name};
    }}

    /// <summary>
    /// Sets a {Table.Name.ToLower()} to inactive
    /// </summary>
    [HttpDelete(""{{{Table.Name.ToLower()}Id}}"")]
    public async Task<{Table.Name}Model> Remove(int {Table.Name.ToLower()}Id, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new Remove{Table.Name}Request
        {{
            {Table.Name}Id = {Table.Name.ToLower()}Id
        }}, cancellationToken);

        return response.{Table.Name};
    }}

    /// <summary>
    /// Sets back a {Table.Name.ToLower()} to active
    /// </summary>
    [HttpPatch(""{{{Table.Name.ToLower()}Id}}"")]
    public async Task<{Table.Name}Model> Restore(int {Table.Name.ToLower()}Id, CancellationToken cancellationToken)
    {{
        User.AllowMinRole(RoleEnum.Admin);

        var response = await _mediator.Send(new Restore{Table.Name}Request
        {{
            {Table.Name}Id = {Table.Name.ToLower()}Id,
        }}, cancellationToken);

        return response.{Table.Name};
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
