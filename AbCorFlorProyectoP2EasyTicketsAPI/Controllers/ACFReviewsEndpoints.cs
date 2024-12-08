using Microsoft.EntityFrameworkCore;
using AbCorFlorProyectoP2EasyTicketsAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ProyectoEasyTicket.Models;
namespace AbCorFlorProyectoP2EasyTicketsAPI.Controllers;

public static class ACFReviewsEndpoints
{
    public static void MapACFReviewsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ACFReviews").WithTags(nameof(ACFReviews));

        group.MapGet("/", async (AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            return await db.ACFReviews.ToListAsync();
        })
        .WithName("GetAllACFReviews")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ACFReviews>, NotFound>> (int acfreviewid, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            return await db.ACFReviews.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ACFReviewID == acfreviewid)
                is ACFReviews model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetACFReviewsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int acfreviewid, ACFReviews aCFReviews, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            var affected = await db.ACFReviews
                .Where(model => model.ACFReviewID == acfreviewid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.ACFReviewID, aCFReviews.ACFReviewID)
                    .SetProperty(m => m.ACFComentario, aCFReviews.ACFComentario)
                    .SetProperty(m => m.ACFCalificacion, aCFReviews.ACFCalificacion)
                    .SetProperty(m => m.ACFFecha, aCFReviews.ACFFecha)
                    .SetProperty(m => m.ACFTicketID, aCFReviews.ACFTicketID)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateACFReviews")
        .WithOpenApi();

        group.MapPost("/", async (ACFReviews aCFReviews, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            db.ACFReviews.Add(aCFReviews);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ACFReviews/{aCFReviews.ACFReviewID}",aCFReviews);
        })
        .WithName("CreateACFReviews")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int acfreviewid, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            var affected = await db.ACFReviews
                .Where(model => model.ACFReviewID == acfreviewid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteACFReviews")
        .WithOpenApi();
    }
}
