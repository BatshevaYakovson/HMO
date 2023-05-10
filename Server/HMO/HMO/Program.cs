using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Repository;
using Repositories.Repository.Interface;
using Services;

namespace HMO
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<HmoDbContext>(opt => opt.UseSqlServer(@"Data Source=DESKTOP-7VCB93M\SQLEXPRESS;Initial Catalog=HMO;Integrated Security=True"));
            builder.Services.AddTransient<IEmployeeCR, EmployeeCR>();
            builder.Services.AddTransient<IEmployeeBL, EmployeeServices>();
            builder.Services.AddTransient<IDiseaseCR, DiseaseCR>();
            builder.Services.AddTransient<IDiseaseBL, DiseaseServices>();

            builder.Services.AddTransient<IVaccinationCR, VaccinationCR>();
            builder.Services.AddTransient<IVaccinationBL, VaccinationServices>();

            builder.Services.AddTransient<IEmplVaccinationCR, EmplVaccinationCR>();
            builder.Services.AddTransient<IEmplVaccinationBL, emplVaccinationServices>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader(); });

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