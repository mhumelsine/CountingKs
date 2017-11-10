using CountingKs.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Infrastructure.Data
{
    public class CountingKsMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            MapFood(modelBuilder);
            MapMeasure(modelBuilder);
            MapDiaryEntry(modelBuilder);
            MapDiary(modelBuilder);
            MapApiUser(modelBuilder);
            MapApiToken(modelBuilder);
        }

        static void MapApiToken(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthToken>().ToTable("AuthToken", "Security");
        }

        static void MapApiUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiUser>().ToTable("ApiUser", "Security");
        }

        static void MapFood(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("Food", "Nutrition");
        }

        static void MapMeasure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measure>().ToTable("Measure", "Nutrition");
        }

        static void MapDiaryEntry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryEntry>().ToTable("DiaryEntry", "FoodDiaries");
        }

        static void MapDiary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diary>().ToTable("Diary", "FoodDiaries");
        }
    }
}
