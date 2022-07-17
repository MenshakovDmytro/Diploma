namespace Basket.Host.Configurations;

public class RedisConfig
{
    public string Host { get; set; } = null!;
    public TimeSpan CacheTimeout { get; set; }
    public bool AbortOnConnectFail { get; set; }
    public int AsyncTimeout { get; set; }
    public int ConnectTimeout { get; set; }
    public int SyncTimeout { get; set; }
}