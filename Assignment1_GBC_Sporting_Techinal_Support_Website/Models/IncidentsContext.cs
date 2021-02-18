using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1_GBC_Sporting_Techinal_Support_Website.Models
{
    public class IncidentsContext : DbContext
    {
        public IncidentsContext(DbContextOptions<IncidentsContext> options) : base(options)
        {   }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        //Many to Many relationship
        public DbSet<Registration> Registrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = 1001,
                    Name = "Draft Manager 1.0",
                    Price = 10.00,
                    ReleaseDate = new DateTime(2020, 1, 10),
                },
                new Product
                {
                    ProductId = 2,
                    Code = 1002,
                    Name = "Tournament Master 1.0",
                    Price = 20.00,
                    ReleaseDate = new DateTime(2020, 2, 20),
                },
                new Product
                {
                    ProductId = 3,
                    Code = 1003,
                    Name = "League Scheduler",
                    Price = 30.00,
                    ReleaseDate = new DateTime(2020, 3, 30),
                }

            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "kor", Name = "Korea" },
                new Country { CountryId = "can", Name = "Canada"},
                new Country { CountryId = "usa", Name = "USA"},
                new Country { CountryId = "jpn", Name = "Japan"},
                new Country { CountryId = "ger", Name = "Germany"}
            );

            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   CustomerId = 1,
                   FirstName = "Jason",
                   LastName = "Kim",
                   Address ="120 Dundas street",
                   City = "Toronto",
                   State = "Ontario",
                   PostalCode = "M2K 2EK",
                   CountryId = "can",
                   Email = "abcde@gmail.com",
                   Phone = "437-684-1234",
               },
               new Customer
               {
                   CustomerId = 2,
                   FirstName = "Suho",
                   LastName = "Lee",
                   Address = "222 Seoul-ro",
                   City = "Jung-gu",
                   State = "Seoul",
                   PostalCode = "04515",
                   CountryId = "kor",
                   Email = "Suho.lee@gmail.com",
                   Phone = "010-1234-1234",
               },
               new Customer
               {
                   CustomerId = 3,
                   FirstName = "Julie",
                   LastName = "Baker",
                   Address = "511-5762 At Rd",
                   City = "Chelsea",
                   State = "MI",
                   PostalCode = "67708",
                   CountryId = "usa",
                   Email = "julie.baker@gmail.com",
                   Phone = "947-278-1234",
               }

            );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    Name = "Alison Diaz",
                    Email = "alison.diaz@gmail.com",
                    Phone = "437-987-6654",
                },
                new Technician
                {
                    TechnicianId = 2,
                    Name = "Kevin Smith",
                    Email = "kevin.smith@gmail.com",
                    Phone = "437-222-2222",
                },
                new Technician
                {
                    TechnicianId = 3,
                    Name = "Servie Garcia",
                    Email = "servie.garcia@gmail.com",
                    Phone = "437-333-3333",
                }

            );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Title = "Could not install",
                    Description = "The file seems like broken, so need to re-download",
                    TechnicianId = 1,
                    DateOpened = DateTime.Now,
                    DateClosed = new DateTime(2021, 5, 1),

                },
                 new Incident
                 {
                     IncidentId = 2,
                     CustomerId = 2,
                     ProductId = 2,
                     Title = "Error importing data",
                     Description = "Error occurs in some point.",
                     TechnicianId = 2,
                     DateOpened = DateTime.Now,
                     DateClosed = new DateTime(2021, 5, 2),

                 },
                  new Incident
                  {
                      IncidentId = 3,
                      CustomerId = 3,
                      ProductId = 3,
                      Title = "Error launching program",
                      Description = "Error occur when is launching program",
                      TechnicianId = 3,
                      DateOpened = DateTime.Now,
                      DateClosed = new DateTime(2021, 5, 3),

                  }

            );


            // @ Have to check
            // Many to Many relationship in Registration        // copied from youtube.com/watch?v=DSP8B6NunzY
            modelBuilder.Entity<Registration>().HasKey(
                c => new {c.CustomerId, c.ProductId}
            );
                
                

        }



    }
}
