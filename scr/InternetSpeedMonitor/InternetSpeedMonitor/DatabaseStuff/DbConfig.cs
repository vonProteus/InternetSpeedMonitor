namespace InternetSpeedMonitor.DatabaseStuff;

public class DbConfig
{
	public static string GetConnectionString()
	{
		var database = Environment.GetEnvironmentVariable("DB_HOST");
		var name = Environment.GetEnvironmentVariable("DB_NAME");
		var user = Environment.GetEnvironmentVariable("DB_USER");
		var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

		var connection = $"Server={database};Database={name};Username={user};password={password};" +
		                 $"Application Name=Internet Speed Monitor";
		return connection;
	}
}