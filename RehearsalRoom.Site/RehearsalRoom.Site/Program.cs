using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RehearsalRoom.Site.Data;
using Microsoft.EntityFrameworkCore;

namespace RehearsalRoom.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            try
            {
                var context = host.Services.GetService(typeof(RehearsalRoomContext)) as RehearsalRoomContext;
                DbInitializer.Initialize(context);
            }
            catch (Exception)
            {
                
                throw;
            }

            host.Run();
        }
    }
}
