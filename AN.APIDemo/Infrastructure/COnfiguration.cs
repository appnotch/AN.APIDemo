using System.Configuration;

namespace AN.APIDemo.Infrastructure
{
	internal static class Configuration
	{
		public static string ANSubject => ConfigurationManager.AppSettings["AN-Subject"];

		public static string ANSecret => ConfigurationManager.AppSettings["AN-Secret"];

		public static string APIUrl => ConfigurationManager.AppSettings["AN-APIUrl"];
	}
}
