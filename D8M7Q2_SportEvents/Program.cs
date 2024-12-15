using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Endpoint.Helpers;
using D8M7Q2_SportEvents.Logic.Helpers;
using D8M7Q2_SportEvents.Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace D8M7Q2_SportEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient(typeof(Repository<>));
            builder.Services.AddTransient<DtoProvider>();
            builder.Services.AddTransient<SportEventLogic>();
            builder.Services.AddTransient<CompetitorLogic>();

            builder.Services.AddDbContext<SportEventContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SportEventsDb;Trusted_Connection=True;TrustServerCertificate=True");
                options.UseLazyLoadingProxies();
            });


            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
                opt.Filters.Add<ValidationFilterAttribute>();
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
