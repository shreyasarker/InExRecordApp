using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InExRecordApp.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Siddharthya Chowdhury",
                    Email = "siddharthya@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    ContactNo = "01713747775",
                    Address = "Banani",
                    Designation = "Sr. Accountant"
                },
                new User
                {
                    Id = 2,
                    Name = "Sohini Azam",
                    Email = "sohini@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    ContactNo = "01916747456",
                    Address = "Dhanmondi",
                    Designation = "Jr. Accountant"
                },
                new User
                {
                    Id = 3,
                    Name = "A K Sen",
                    Email = "sen@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    ContactNo = "01816749274",
                    Address = "Mohakhali DOHS",
                    Designation = "Jr. Accountant"
                },
                new User
                {
                    Id = 4,
                    Name = "Thomas Barua",
                    Email = "thomas@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    ContactNo = "01772939284",
                    Address = "Gulshan",
                    Designation = "Sr. Accountant"
                });
        }
    }
}
