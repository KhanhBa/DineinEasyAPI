
using AutoMapper;
using DineinEasy.API.Utilities;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json.Serialization;

namespace DineinEasy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddScoped<IAreaService,AreaService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddScoped<IBannerService, BannerService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
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
