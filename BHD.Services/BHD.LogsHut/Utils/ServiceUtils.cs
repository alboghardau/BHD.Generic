using System;
using BHD.LogsHut.Interfaces;
using BHD.LogsHut.Mock;
using BHD.LogsHut.Services;
using BHD.LogsHut.Utils.Writers;

namespace BHD.LogsHut.Utils
{
	public class ServiceUtils
	{
		public static void RegisterServices(WebApplicationBuilder builder)
		{
			//Singletons
			builder.Services.AddSingleton<LoggerService>();
			builder.Services.AddSingleton<WriterService>();
			builder.Services.AddSingleton<IMockService, MockService>();

            //Transient
            builder.Services.AddTransient<ILogGenerator, LogGenerator>();
			builder.Services.AddTransient<ILogWriter, ConsoleWriter>();
        }
	}
}

