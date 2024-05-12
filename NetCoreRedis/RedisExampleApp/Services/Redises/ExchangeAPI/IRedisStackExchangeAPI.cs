using StackExchange.Redis;

namespace RedisExampleApp.Services.Redises.ExchangeAPI
{
    /// <summary>
    /// Uso de la API de Redis StackExchange
    /// Administrador de paquetes Nuget: StackExchange.Redis
    /// </summary>
    public interface IRedisStackExchangeAPI
    {
        /// <summary>
        /// Llamo al método ConnectAsync en el lado del Middleware (Configure) y establezco la conexión con redis.
        /// </summary>
        void ConnectServer();

        /// <summary>
        /// Especifico la base de datos que quiero procesar en el lado de Redis
        /// </summary>
        /// <param name="databaseIndex">índice de base de datos</param>
        /// <returns>IDatabase</returns>
        IDatabase GetSelectedDatabase(int databaseIndex = 0);
    }
}
