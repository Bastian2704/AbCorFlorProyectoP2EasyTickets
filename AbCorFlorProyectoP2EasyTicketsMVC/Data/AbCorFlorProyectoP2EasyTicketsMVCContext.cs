using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEasyTicket.Models;

namespace AbCorFlorProyectoP2EasyTicketsMVC.Data
{
    public class AbCorFlorProyectoP2EasyTicketsMVCContext : DbContext
    {
        public AbCorFlorProyectoP2EasyTicketsMVCContext (DbContextOptions<AbCorFlorProyectoP2EasyTicketsMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEasyTicket.Models.ACFReviews> ACFReviews { get; set; } = default!;
        public DbSet<ProyectoEasyTicket.Models.ACFTicket> ACFTicket { get; set; } = default!;
    }
}
