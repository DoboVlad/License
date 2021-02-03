using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSearch.Models;

namespace TeamSearch.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Language> LANGUAGES { get; set; }

        public DbSet<Field> FIELDS { get; set; }

        public DbSet<Team> TEAM { get; set; }
    }
}
