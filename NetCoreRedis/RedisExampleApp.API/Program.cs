namespace RedisExampleApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Start: Services added for this project 

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDB");
            });

            builder.Services.AddSingleton<RedisService>(provider =>
            {
                return new RedisService(builder.Configuration["CacheOptions:Url"]);
            });

            builder.Services.AddSingleton<IDatabase>(provider =>
            {
                var redisService = provider.GetRequiredService<RedisService>();
                return redisService.GetDb(0);
            });

            builder.Services.AddScoped<IProductRepository>(provider =>
            {
                var appDbContext = provider.GetRequiredService<AppDbContext>();
                var redisService = provider.GetRequiredService<RedisService>();
                //var logger = provider.GetRequiredService<ILogger<ProductRepositoryWithLogDecorator>>();

                var productRepository = new ProductRepository(appDbContext);
                //var productRepositoryWithCacheDecorator = new ProductRepositoryWithCacheDecorator(productRepository, redisService);
                //var productRepositoryWithLogDecorator = new ProductRepositoryWithLogDecorator(logger, productRepositoryWithCacheDecorator);

                //return productRepositoryWithLogDecorator;
                return productRepository;
            });

            builder.Services.AddScoped<IProductService, ProductService>();

            //End: Services added for this project 

            var app = builder.Build();

            //Start: Middleware or pipe line of http request. added for this project

            using (var serviceScope = app.Services.CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                appDbContext.Database.EnsureCreated();
            }


            //End: Middleware or pipe line of http request. added for this project 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
