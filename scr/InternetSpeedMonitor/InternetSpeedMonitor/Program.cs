// See https://aka.ms/new-console-template for more information

using InternetSpeedMonitor.DatabaseStuff;
using InternetSpeedMonitor.SpeedTest;

var speedTest = new SpeedTest();
var speedResult = speedTest.MeasureNow();

Console.WriteLine(speedResult.RawJson);
try
{
	using (var db = new InternetSpeedMonitorDatabaseContext())
	{
		db.Init();
		db.SpeedResults.Add(speedResult);
		db.SaveChanges();
	}

	Console.WriteLine("added to db");
}
catch (Exception e)
{
	Console.WriteLine(e);
	Environment.Exit(1);
}

Environment.Exit(0);