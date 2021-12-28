using System.Diagnostics;
using System.Text.Json.Nodes;
using InternetSpeedMonitor.Data;

namespace InternetSpeedMonitor.SpeedTest;

public class SpeedTest
{
	public SpeedResult MeasureNow()
	{
		var speedTestRawJson = GetSpeedTestRawJson();
		return SpeedResultFromJson(speedTestRawJson);
	}

	private SpeedResult SpeedResultFromJson(
		string speedTestRawJson)
	{
		var json = JsonValue.Parse(speedTestRawJson);
		
		return new SpeedResult
		{
			Download = json["download"]["bandwidth"].GetValue<int>() * 8,
			Upload = json["upload"]["bandwidth"].GetValue<int>() * 8,
			Ping = TimeSpan.FromMilliseconds(json["ping"]["latency"].GetValue<double>()),
			Timestamp = DateTime.Parse(json["timestamp"].ToString()).ToUniversalTime(),
			URL = json["result"]["url"].ToString(),
			RawJson = speedTestRawJson
		};
	}

	private string GetSpeedTestRawJson()
	{
		var process = new Process();
		process.StartInfo.FileName = "speedtest";
		process.StartInfo.Arguments = "--accept-license --accept-gdpr -f json";
		process.StartInfo.RedirectStandardOutput = true;
		process.Start();
		var output = process.StandardOutput.ReadToEnd();
		process.WaitForExit();
		return output;
	}
}