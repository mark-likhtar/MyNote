using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;

namespace MyNote
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("DBConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Archive> Archives { get; set; }
    }
}