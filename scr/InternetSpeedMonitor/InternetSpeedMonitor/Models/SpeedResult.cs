
namespace InternetSpeedMonitor.Data;

public class SpeedResult
{
	public long Id { get; set; }
	public int Download { get; set; }
	public int Upload { get; set; }
	public DateTime Timestamp { get; set; }
	public double Ping { get; set; }
	public string URL { get; set; }
	public string RawJson { get; set; }
}