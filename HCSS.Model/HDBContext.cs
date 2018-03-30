using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HCSS.Model.Entity;

namespace HCSS.Model
{
    public class HDBContext : DbContext
    {
        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
        public HDBContext(DbContextOptions<HDBContext> options) : base(options)
        {
            //在此可对数据库连接字符串做加解密操作      
        }

        public DbSet<ElderInfo> ElderInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
        }
    }
}