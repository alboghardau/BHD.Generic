using BHD.Logger.Interfaces;
using BHD.Logger.Writers;
using BHD.LogsHut.Services;

namespace BHD.LogsHut.Utils
{
	public class ServiceUtils
	{
		public static void RegisterServices(WebApplicationBuilder builder)
		{
			//Singletons
			builder.Services.AddSingleton<LoggerService>();
			builder.Services.AddSingleton<WriterService>();

            //Transient
			builder.Services.AddTransient<ILogWriter, ConsoleWriter>();
        }
	}
}

