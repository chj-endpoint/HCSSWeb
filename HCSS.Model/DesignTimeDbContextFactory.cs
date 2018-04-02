using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HCSS.Model
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HDBContext>

    {

        public HDBContext CreateDbContext(string[] args)

        {

            Directory.SetCurrentDirectory("..");//设置当前路径为当前解决方案的路径

            string appSettingBasePath = Directory.GetCurrentDirectory() + "/HCSS.WebApi";//改成你的appsettings.json所在的项目名称

            var configBuilder = new ConfigurationBuilder()

                .SetBasePath(appSettingBasePath)

                .AddJsonFile("appsettings.json")

                .Build();



            var builder = new DbContextOptionsBuilder<HDBContext>();

            //builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Light;");

            builder.UseMySql(configBuilder.GetConnectionString("HDBConnection"));

            return new HDBContext(builder.Options);

        }

    }
}