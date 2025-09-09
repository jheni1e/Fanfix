using Fanfix.UseCases.EditList;
using Fanfix.UseCases.SearchList;
using Microsoft.AspNetCore.Mvc;

namespace Fanfix.Endpoints;

public static class ReadingListEndpoints
{
    public static void ConfigureReadingListEndpoints(this WebApplication app)
    {
        app.MapPost("search", async (
            [FromBody] SearchListPayload payload,
            [FromServices] SearchListUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();

            return Results.Ok(result.Data);
        });
        
        app.MapPut("edit/list", async (
            [FromBody] EditListPayload payload,
            [FromServices] EditListUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);
            
            if (!result.IsSuccess)
                return Results.BadRequest();

            return Results.Ok(result.Data);
        });
    }
}