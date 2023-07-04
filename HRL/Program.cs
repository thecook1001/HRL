using Blazored.Modal;
using DatenbankInBVLazor;
using HRL.Database;
using HRL.Service;

namespace HRL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredModal();
            builder.Services.AddSingleton<IPlcConnectionService, PlcConnectionService>();
            builder.Services.AddTransient<HRLContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            /*using (var dbContext = new HRLContext())
            {
                dbContext.Database.EnsureCreated();
            }

            Task.Run(() => new DataCrawler().Crawl());
            */
            app.Run();

        }
    }
}