using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using LLY.LifeTask.Model.Life;
using LLY.LifeTask.Model.EntityFramework.Life.Map;

namespace LLY.LifeTask.Model.EntityFramework
{
    public class LifeDbContext : DbContext
    {
        public LifeDbContext(DbContextOptions<LifeDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<SaleOrder> SaleOrders { get; set; }


        /*配置DbContext
         两种方式：
            1.Constructor argument 
                通过Startup.cs 配置ConfigServices 配置 DbContextOptions
                    services.AddDbContext<SchoolContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                或者 
                    var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
                    optionsBuilder.UseSqlite("Filename=./blog.db");

                    using (var context = new BloggingContext(optionsBuilder.Options))
                    {
                    }

            2.OnConfiguring
                这种方式的优先级最高，可以覆盖第一种方式的配置，但是缺点是不容易测试

        */

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "data source='.';initial catalog=LifeNext;persist security info=True;user id=sa;password=SQL2014P@ssword;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SaleOrder>().ToTable("SaleOrders");
            SaleOrderMap.Map(modelBuilder.Entity<SaleOrder>());
        }
    }
}
