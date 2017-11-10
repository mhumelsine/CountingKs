using CountingKs.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Infrastructure.Data
{
    public class CountingKsContext : DbContext
    {
        public CountingKsContext(DbContextOptions<CountingKsContext> options)
            :base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CountingKsMapping.Configure(modelBuilder);
        }

        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
    }
}
