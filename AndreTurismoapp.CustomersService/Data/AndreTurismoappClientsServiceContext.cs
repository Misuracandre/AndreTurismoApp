using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.ClientsService.Data
{
    public class AndreTurismoAppClientsServiceContext : DbContext
    {
        public AndreTurismoAppClientsServiceContext (DbContextOptions<AndreTurismoAppClientsServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Client> Client { get; set; } = default!;
    }
}
