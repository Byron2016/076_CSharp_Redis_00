namespace RedisExampleApp.Models.Settings
{
    /// <summary>
    /// Configuración de Redis
    /// </summary>
    public class RedisSettings
    {
        /// <summary>
        /// Dirección del host de Redis
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Puerto donde se ejecuta Redis
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// En caso de no conectarse a Redis
        /// </summary>
        public bool AbortOnConnectFail { get; set; }

        /// <summary>
        /// Rediseñe las solicitudes asíncronas para que expiren el tiempo de espera si se proporciona una respuesta después de los segundos que especifico.
        /// </summary>
        public int AsyncTimeOutMilliSecond { get; set; }

        /// <summary>
        /// Para solicitudes normales, si se proporciona una respuesta después de los segundos que especifico, se reducirá el tiempo de espera.
        /// </summary>
        public int ConnectTimeOutMilliSecond { get; set; }
    }
}