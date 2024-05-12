# 076_CSharp_Redis_00

- Origen: https://github.com/cihatsolak/net7-redis-database

- REDIS_SERVICE 
	- Class Library: A project for creating a class library that targets .NET or .NET Standard.
	- Add referento to API.
	- Packages 
		- StackExchange.Redis
	- Add RedisService Class
	
	
- API 
	- ASP.NET Core Web API 
		- Framework: .NET 8.0
		- Authentication Type: None
		- Configure for HTTPS
		- Enable OpenAPI support
		- Do not use top-level statements
		- Use controllers
		
	- Packages 
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.InMemory
		- 
	- Ejecución
		- https://localhost:7221/weatherForecast
		
	- Add Models / Repositories / Services
	- Add Controllers
	- Add reference to REDIS_SERVICE
		
	- provider.GetRequiredService	

	- TODO
		- para qué sirve: Microsoft.AspNetCore.OpenApi 
		
		
- RedisExampleApp
	- ASP.NET Core Web App (Model-View-Controller)
	
	- Packages
		- StackExchange.Redis
		- Microsoft.Extensions.Caching.StackExchangeRedis
		
	- References
		- The difference between GetService() and GetRequiredService() in ASP.NET Core
			- https://andrewlock.net/the-difference-between-getservice-and-getrquiredservice-in-asp-net-core/
		- 
	- Funcionamiento
		- En appsettings.json están una entrada RedisSttings con los parámetros de conexión a la base de datos.
		- Estos parámetros son ingresado en la clase RedisSettings a través del servicio 
			- builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection(nameof(RedisSettings)));
		- Posteriormente se ejecuta el middelware que llama a la conexión con servidor de Redis.
			- var redisStackExchangeAPI= app.Services.GetRequiredService<IRedisStackExchangeAPI>();
			  redisStackExchangeAPI.ConnectServer();

	