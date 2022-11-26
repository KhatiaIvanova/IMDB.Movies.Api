
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using Movies.Application.Interfaces;
using Movies.Application.Queries;
using Movies.Application.Queries.WatchHistory;
using Movies.Infrastructure;
using Movies.Infrastructure.ApiServices;

namespace Movies.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddInfrastructure();
            services.AddHttpClient();
            services.AddCors();
            services.AddControllers();


            services.AddMediatR(typeof(MoviesQuery).Assembly);

            services.AddSingleton<IIMdbSearchService, ImdbSearchService>();

            //validator
            services.AddScoped<IValidator<MoviesQuery>, MoviesQueryValidator>();
            services.AddScoped<IValidator<AddWatchHistoryItemRequest>, AddWatchHistoryItemValidator>();
            services.AddScoped<IValidator<UpdateWatchHistoryItem>, UpdateWatchHistoryItemValidator>();
            services.AddScoped<IValidator<GetWatchHistory>, GetWatchHistoryValidator>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Space Movies", Version = "v1" }));
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(policy =>
            {
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
            });


            app.UseSwagger();
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Space");
                c.DisplayRequestDuration();
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/healthz", context => context.Response.WriteAsync("ok"));
            });
        }
    }
}