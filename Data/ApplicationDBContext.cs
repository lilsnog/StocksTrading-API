using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext//Inheritance 
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) //Passing-up dbContextOptions into DbContext
        {
            
        }

        public DbSet<Stock> Stocks { get; set;} //Allow access to stock table (DbSet is used in manupulating table)
        public DbSet<Comment> Comments { get; set; } //Allow access to stock table (DbSet is used in manupulating table)
    }
}