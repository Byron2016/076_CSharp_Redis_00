# 076_CSharp_Redis_00

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
	- Console application.
	