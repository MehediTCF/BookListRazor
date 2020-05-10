using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistApp.Model
{
    public class ApplicationDbContext : DbContext
    {
        //empty contructor, but the parameter is needed for dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }
        public DbSet<Booklist> booklist { get; set; }
    }
}
