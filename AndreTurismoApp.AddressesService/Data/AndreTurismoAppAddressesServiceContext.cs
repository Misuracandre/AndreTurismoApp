using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models.DTO;

namespace AndreTurismoApp.AddressesService.Data
{
    public class AndreTurismoAppAddressesServiceContext : DbContext
    {
        public AndreTurismoAppAddressesServiceContext (DbContextOptions<AndreTurismoAppAddressesServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.City> City { get; set; } = default!;

        public DbSet<AndreTurismoApp.Models.Address> Address { get; set; }

        public DbSet<AndreTurismoApp.Models.Client> Client { get; set; }

        public DbSet<ViaCepAddressDto> ViaCepAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViaCepAddressDto>().HasNoKey();
        }

    }
}
