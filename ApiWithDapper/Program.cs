
using System.Data;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using ApiWithDapper.Interfaces;
using ApiWithDapper.Repositories;
using ApiWithDapper.Services;

namespace ApiWithDapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy.WithOrigins("http://example.com",
            //                                              "http://www.contoso.com");
            //                      });
            //});
            //WithOrigins("http://example.com",
            //                                              "http://www.contoso.com",
            //                                              "http://127.0.0.1:5500/index.html",
            //                                              "https://localhost:7147");

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //creating db connection, as per dapper docs ethan sent on the 12th of feb
            var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
            
            //you would have dependency injection for Unit of work, IClientRepo, IClientDetailsRepo, i think
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();//whenever an IUnitOfWork is required, create a UnitOfWork and pass that in
            builder.Services.AddTransient<IClientRepository, ClientRepository>();//whenever an IClientRepository is required, create a client repository and pass that in
            builder.Services.AddTransient<IClientDetailsRepository, ClientDetailsRepository>();
            builder.Services.AddTransient<IClientServices, ClientServices>();
                        
            // Register your regular repositories
            //services.AddScoped<IDiameterRepository, DiameterRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
