using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VueSampleApp.Data.Models;

namespace VueSampleApp.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options){ }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
