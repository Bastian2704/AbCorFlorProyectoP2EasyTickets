using Microsoft.EntityFrameworkCore;
using AbCorFlorProyectoP2EasyTicketsAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ProyectoEasyTicket.Models;
namespace AbCorFlorProyectoP2EasyTicketsAPI.Controllers;

public static class ACFTicketEndpoints
{
    public static void MapACFTicketEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ACFTicket").WithTags(nameof(ACFTicket));

        group.MapGet("/", async (AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            return await db.ACFTicket.ToListAsync();
        })
        .WithName("GetAllACFTickets")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ACFTicket>, NotFound>> (int acfticketid, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            return await db.ACFTicket.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ACFTicketID == acfticketid)
                is ACFTicket model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetACFTicketById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int acfticketid, ACFTicket aCFTicket, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            var affected = await db.ACFTicket
                .Where(model => model.ACFTicketID == acfticketid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.ACFTicketID, aCFTicket.ACFTicketID)
                    .SetProperty(m => m.ACFEvento, aCFTicket.ACFEvento)
                    .SetProperty(m => m.ACFFecha, aCFTicket.ACFFecha)
                    .SetProperty(m => m.ACFLugar, aCFTicket.ACFLugar)
                    .SetProperty(m => m.ACFButacaSeccion, aCFTicket.ACFButacaSeccion)
                    .SetProperty(m => m.ACFPrecio, aCFTicket.ACFPrecio)
                    .SetProperty(m => m.ACFTelefono, aCFTicket.ACFTelefono)
                    .SetProperty(m => m.ACFVendido, aCFTicket.ACFVendido)
                    .SetProperty(m => m.ACFContrasenia, aCFTicket.ACFContrasenia)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateACFTicket")
        .WithOpenApi();

        group.MapPost("/", async (ACFTicket aCFTicket, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            db.ACFTicket.Add(aCFTicket);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ACFTicket/{aCFTicket.ACFTicketID}",aCFTicket);
        })
        .WithName("CreateACFTicket")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int acfticketid, AbCorFlorProyectoP2EasyTicketsAPIContext db) =>
        {
            var affected = await db.ACFTicket
                .Where(model => model.ACFTicketID == acfticketid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteACFTicket")
        .WithOpenApi();
    }
}
