using System;
using System.Collections.Generic;
using System.Text;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iBlogHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<SocialProfiles> SocialProfiles { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<PostMedias> PostMedias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsPostsRelations> TagsPostsRelations { get; set; }
        public DbSet<Newsletters> Newsletters { get; set; }
        public DbSet<Bookmarks> Bookmarks { get; set; }
    }
}
