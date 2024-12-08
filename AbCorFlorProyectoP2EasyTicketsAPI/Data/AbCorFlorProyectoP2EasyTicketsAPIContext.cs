using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEasyTicket.Models;

namespace AbCorFlorProyectoP2EasyTicketsAPI.Data
{
    public class AbCorFlorProyectoP2EasyTicketsAPIContext : DbContext
    {
        public AbCorFlorProyectoP2EasyTicketsAPIContext (DbContextOptions<AbCorFlorProyectoP2EasyTicketsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEasyTicket.Models.ACFTicket> ACFTicket { get; set; } = default!;
        public DbSet<ProyectoEasyTicket.Models.ACFReviews> ACFReviews { get; set; } = default!;
    }
}
