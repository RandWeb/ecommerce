using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.SeriLogger
{
    public static class SeriLogExtentions
    {
        public static void UseSeriLogSqlServer(this IWebHostBuilder builder)
        {
            builder.UseSerilog((b, logger) =>
            {
                logger = new SerilogConfig().ConfigSqlServer(LogEventLevel.Warning);
                logger.CreateLogger();
            });
        }
        public static void UseSeriLogConsole(this IWebHostBuilder builder)
        {
            builder.UseSerilog((builder, logger) =>
            {
                logger.WriteTo.Console().MinimumLevel.Is(LogEventLevel.Verbose);
            });
        }
    }
}
