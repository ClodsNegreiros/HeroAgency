using HeroAgency.Application.Commands.SuperHero.CreateHero;
using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.UseCases;
using HeroAgency.Application.UseCases.SuperHero.Commands;
using HeroAgency.Application.UseCases.SuperHero.Queries;
using HeroAgency.Domain.Interfaces;
using HeroAgency.Infrastructure.Context;
using HeroAgency.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HeroAgency
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

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));


            // Add Mediator DI
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                        AppDomain.CurrentDomain.GetAssemblies()
                    ));

            // UseCase DI
            builder.Services.AddScoped<ICreateSuperHeroUseCase, CreateSuperHeroUseCase>();
            builder.Services.AddScoped<IUpdateSuperHeroUseCase, UpdateSuperHeroUseCase>();
            builder.Services.AddScoped<IDeleteSuperHeroUseCase, DeleteSuperHeroUseCase>();
            builder.Services.AddScoped<IGetAllSuperHeroUseCase, GetAllSuperHeroUseCase>();

            // Repository DI
            builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();

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
