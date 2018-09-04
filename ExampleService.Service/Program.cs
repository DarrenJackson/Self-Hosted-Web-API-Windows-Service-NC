using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExampleService.Service
{
	using System.Diagnostics;
	using Microsoft.AspNetCore.Hosting.WindowsServices;

	public static class Program
	{
		public static void Main(string[] args)
		{
			var isService = !(Debugger.IsAttached || args.Contains("--Console"));
			var builder = CreateWebHostBuilder(args.Where(a => a != "--console").ToArray());

			if (isService)
			{
				var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
				var pathToContentRoot = Path.GetDirectoryName(pathToExe);
				builder.UseContentRoot(pathToContentRoot);
			}

			var host = builder.Build();

			if (isService)
			{
				host.RunAsService();
			}
			else
			{
				host.Run();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((context, config) =>
				{
					// Configure app here	
				})
				.UseStartup<Startup>();
		}
	}
}
