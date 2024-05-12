using RedisExampleApp.Models.Settings;
using RedisExampleApp.Services.Redises.ExchangeAPI;

namespace RedisExampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Start: Services added for this project 

            #region DistributedCache configuración
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
            //builder.Services.AddSingleton<IRedisDistributedService, RedisDistributedManager>();
            #endregion

            #region StackExchange.Redis configuración
            builder.Services.AddSingleton<IRedisStackExchangeAPI, RedisStackExchangeAPI>();
            builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection(nameof(RedisSettings)));
            #endregion

            //End: Services added for this project 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Start: Middleware or pipe line of http request. added for this project

            var redisStackExchangeAPI= app.Services.GetRequiredService<IRedisStackExchangeAPI>();

            redisStackExchangeAPI.ConnectServer();

            //End: Middleware or pipe line of http request. added for this project 

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
