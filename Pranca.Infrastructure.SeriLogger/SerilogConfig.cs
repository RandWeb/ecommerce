using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.SeriLogger
{
    internal class SerilogConfig
    {
        public LoggerConfiguration ConfigSqlServer(LogEventLevel logEventLevel)
        {
            var ColumnOpt = new ColumnOptions();
            ColumnOpt.Store.Remove(StandardColumn.Properties);
            ColumnOpt.Store.Add(StandardColumn.LogEvent);
            ColumnOpt.LogEvent.DataLength = -1;
            ColumnOpt.PrimaryKey = ColumnOpt.TimeStamp;
            ColumnOpt.TimeStamp.NonClusteredIndex = true;

            return new LoggerConfiguration()
                                .Enrich.FromLogContext()
                                .MinimumLevel.Is(logEventLevel)
                                .WriteTo.MSSqlServer("Data Source=.;Initial Catalog=SerilogBeautyDb;Integrated Security=True;", new MSSqlServerSinkOptions
                                {
                                    AutoCreateSqlTable = true,
                                    TableName = "BeautyLogs",
                                    BatchPeriod = new TimeSpan(0, 0, 1)
                                },
                                columnOptions: ColumnOpt);
        }
    }
}
