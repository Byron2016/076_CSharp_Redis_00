using Microsoft.Extensions.Options;
using RedisExampleApp.Models.Settings;
using StackExchange.Redis;


namespace RedisExampleApp.Services.Redises.ExchangeAPI
{
    /// <summary>
    /// Uso de la API de Redis StackExchange
    /// Nuget Package Manager: StackExchange.Redis
    /// </summary>
    public class RedisStackExchangeAPI : IRedisStackExchangeAPI
    {
        private readonly RedisSettings _redisSettings;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisStackExchangeAPI(IOptions<RedisSettings> redisSettings)
        {
            _redisSettings = redisSettings.Value;
        }

        /// <summary>
        /// Llamo al método ConnectAsync en el lado del Middleware (Configurar) y establezco la conexión con redis.
        /// </summary>
        public async void ConnectServer()
        {
            var configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { string.Concat(_redisSettings.Host, ":", _redisSettings.Port) },
                AbortOnConnectFail = _redisSettings.AbortOnConnectFail,
                AsyncTimeout = _redisSettings.AsyncTimeOutMilliSecond,
                ConnectTimeout = _redisSettings.ConnectTimeOutMilliSecond
            };

            _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
        }

        /// <summary>
        /// Del lado de Redis, especifico la base de datos que quiero procesar.
        /// </summary>
        /// <param name="databaseIndex">índice de base de datos</param>
        /// <returns>IDatabase</returns>
        public IDatabase GetSelectedDatabase(int databaseIndex = 0)
        {
            return _connectionMultiplexer.GetDatabase(databaseIndex);
        }
    }
}
