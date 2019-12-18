using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? LockoutEndDateUtc { set; get; }
        public bool IsVip { set; get; }
        public DateTime? VipExp { set; get; }
        public bool IsEnable { set; get; }
    }
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Course> Courses { set; get; }
        public DbSet<Lesson> Lessons { set; get; }
        public DbSet<Topic> Topics { set; get; }
    }
}
