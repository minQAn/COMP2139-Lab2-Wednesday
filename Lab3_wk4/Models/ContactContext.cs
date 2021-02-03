using System;

using Microsoft.EntityFrameworkCore;


namespace Lab3_wk4.Models
{
    public class ContactContext : DbContext
    {

        public ContactContext(DbContextOptions<ContactContext> options) : base (options)
        {
           
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, name = "Family" },
                new Category { CategoryId = 2, name = "Friend" },
                new Category { CategoryId = 3, name = "Work" },
                new Category { CategoryId = 4, name = "Other" }
            );

            modelBuilder.Entity<Contact>().HasData(

                new Contact
                {
                    ContactId = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Phone = "416-123-4567",
                    Email = "bruce.wayne@domain.com",
                    CategoryId = 1,
                    DateAdded = DateTime.Now,
                },


                new Contact
                {
                    ContactId = 2,
                    FirstName = "Peter",
                    LastName = "Parker",
                    Phone = "647-123-4567",
                    Email = "peter.parker@domain.com",
                    CategoryId = 2,
                    DateAdded = DateTime.Now,
                },

                new Contact
                {
                    ContactId = 3,
                    FirstName = "Diana",
                    LastName = "Prince",
                    Phone = "905-123-4567",
                    Email = "diana.prince@domain.com",
                    CategoryId = 3,
                    DateAdded = DateTime.Now,
                }
            );

        }
    }
}
