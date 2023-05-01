using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoapp.CustomersService.Data
{
    public class AndreTurismoappCustomersServiceContext : DbContext
    {
        public AndreTurismoappCustomersServiceContext (DbContextOptions<AndreTurismoappCustomersServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Client> Client { get; set; } = default!;
    }
}
