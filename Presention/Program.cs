using Application.Contracts.Hall;
using Application.Contracts.Interwoven;
using Application.Contracts.Machine;
using Application.Contracts.OptionPackaging;
using Application.Hall;
using Application.InterwovenManagement;
using Application.Machine;
using Application.OptionPackaging;
using Domain;
using Infrastructure;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Presention
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<Context>(Option =>
                Option.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreSQLServer")));
            builder.Services.AddTransient<IRepository<Domain.Machine>, Repository<Domain.Machine>>();
            builder.Services.AddTransient<IRepository<Hall>, Repository<Hall>>();
            builder.Services.AddTransient<IRepository<Domain.label>, Repository<Domain.label>>();
            builder.Services.AddTransient<IRepository<OptionPackaging>, Repository<OptionPackaging>>();

            builder.Services.AddTransient<IHallApplication, HallApplication>();
            builder.Services.AddTransient<IMachineApplication, MachineApplication>();
            builder.Services.AddTransient<IOptionPackagingApplication, OptionPackagingApplication>();
            builder.Services.AddTransient<IInterwovenManagementApplicaion, InterwovenManagementApplicaion>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapRazorPages();

            app.Run();
        }
    }
}
