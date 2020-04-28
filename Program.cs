using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TeamSpeak.Sdk;
using TeamSpeak.Sdk.Client;

namespace TeamSpeakTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var libraryParameters = new LibraryParameters("/home/naumov_evg/work/ts/ts3_sdk_3.0.4/bin")
            {
                UsedLogTypes = LogTypes.Console | LogTypes.Database | LogTypes.File | LogTypes.Syslog |
                               LogTypes.Userlogging,
            };

            try
            {
                Library.Initialize(libraryParameters);
            }
            catch (DllNotFoundException)
            {
                Console.WriteLine("1");
            }

            using var connection = new Connection();
            connection.Start(Library.CreateIdentity(), "meet.clickon.ru", 9987, "naumov_evg_bot", "AFK", "", "602077");
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}