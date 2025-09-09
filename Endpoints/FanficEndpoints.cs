using Fanfix.UseCases.CreateFanfic;
using Fanfix.UseCases.DeleteFanfic;
using Microsoft.AspNetCore.Mvc;

namespace Fanfix.Endpoints;

public static class FanficEndpoints
{
    public static void ConfigureFanficEndpoints(this WebApplication app)
    {
        app.MapPost("create/fanfic", async (
            [FromBody] CreateFanficPayload payload,
            [FromServices] CreateFanficUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();

            return Results.Ok(result.Data);
        });
        
        app.MapPost("delete/fanfic", async (
            [FromBody] DeleteFanficPayload payload,
            [FromServices] DeleteFanficUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();

            return Results.Ok(result.Data);
        });
    }
}