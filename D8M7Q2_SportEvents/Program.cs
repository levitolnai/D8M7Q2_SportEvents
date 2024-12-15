
using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Logic;
using Microsoft.EntityFrameworkCore;
using MovieClub.Data;

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

            builder.Services.AddDbContext<SportEventContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SportEventsDb;Trusted_Connection=True;TrustServerCertificate=True");
            });


            builder.Services.AddControllers();
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
