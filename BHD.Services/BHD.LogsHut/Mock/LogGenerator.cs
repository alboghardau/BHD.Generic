using System;
using BHD.Logger.Enums;
using BHD.LogsHut.Interfaces;
using BHD.Logger.Models;
using BHD.LogsHut.Utils;

namespace BHD.LogsHut.Mock
{
    public class LogGenerator : ILogGenerator
    {
        public LogGenerator()
        {

        }

        public Log GetRandomLog()
        {
            var log = new Log();

            log.Time = DateTime.UtcNow;
            log.LogLevel = this.GetRandomLogLevel();
            log.Service = this.GetRandomService();
            log.Message = this.GetRandomMessage();
            log.IpAdress = this.GetRandomIP();
            log.User = this.GetRandomUser();

            return log;
        }

        private LogLevels GetRandomLogLevel()
        {
            return EnumUtils.GetRandomEnumElement<LogLevels>();
        }

        private string GetRandomService()
        {
            var services = new[] { "Gateway", "BL", "DBService", "Vault Service" };

            return ArrayUtils.GetRandomElement<string>(services);
        }

        private string GetRandomMessage()
        {
            var messages = new[]
            {
                "Failed to connect to database server at",
                "Incoming request with invalid authentication token",
                "Processing request for resource",
                "Critical error occurred. System shutting down...",
                "Executing SQL query: SELECT * FROM orders WHERE order_id = 12345",
                "Unexpected response from server: HTTP 500 Internal Server Error",
                "Slow database query detected. Execution time: 2.5 seconds",
                "Found 10 matching results for search query ",
                "Successfully authenticated user Dorel"
            };

            return ArrayUtils.GetRandomElement<string>(messages);
        }

        private string GetRandomIP()
        {
            var ipAdresses = new[] { "192.168.0.100", "192.168.2.200", "192.168.50.10", "192.168.30.15" };

            return ArrayUtils.GetRandomElement<string>(ipAdresses);
        }

        private string GetRandomUser()
        {
            var users = new[] { "Dorel234" , "Gogu4242", "Mike4321", "Lisa34234"};

            return ArrayUtils.GetRandomElement<string>(users);
        }
    }
}

