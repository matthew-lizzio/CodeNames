using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mml.CodeNames.Backend.DataAccessLibrary;

namespace mml.CodeNames.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CodeNames.db");
            DataAccess.InitializeDatabase();
            CreateHostBuilder(args).Build().Run();           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static string DatabasePath { get; private set; }
    }
}
