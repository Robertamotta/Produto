using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace Estoque.WebAPI.Controllers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }
        public IServiceCollection Conn { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableSystemDiagnosticsTracing();

            // Other configuration code not shown.
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers();
            //[inicio]
            //Conn = services.AddDbContext<DbContext>(options =>
            //      options.UseSqlServer("Server=tcp:estoque-infrastruture-db-server.database.windows.net,1433;Initial Catalog=Estoque.Infrastruture_db;Persist Security Info=False;User ID=treinamentormp;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;;"));

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = "Server = tcp:estoque - infrastruture - db - server.database.windows.net,1433; Initial Catalog = Estoque.Infrastruture_db; Persist Security Info = False; User ID = treinamentormp; Password = Rmp251702; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            builder.DataSource = "estoque-infrastruture-db-server.database.windows.net";
            builder.UserID = "treinamentormp";
            builder.Password = "Rmp251702";
            builder.InitialCatalog = "Estoque.Infrastruture_db";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

            }

            var ConnectionString = Configuration.GetConnectionString("ConexaoMySql");
            services.AddDbContext<Estoque.WebAPI.Models.EstoqueInfrastruture_dbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EstoqueInfrastruture_dbContext"))
            );

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Version = "v1",
                       Title = "Estoque API",
                       Description = "API's do Trabalho Final",
                       TermsOfService = new Uri("https://example.com/terms"),
                       Contact = new OpenApiContact
                       {
                           Name = "Roberta Motta",
                           Email = "robertamotta.13@gmail.com",
                        // Url = new Uri("https://www.squadra.com.br/"),
                    },
                       License = new OpenApiLicense
                       {
                           Name = "Use under LICX",
                           Url = new Uri("https://example.com/license"),
                       }

                   });

                // Set the comments path for the Swagger JSON and UI.
                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);
               });

            //services.AddDbContext<EstoqueContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("EstoqueContext")));

            //services.AddDbContext<ProdutoContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("ProdutoContext")));

         }

        private void IncludeXmlComments(string xmlPath)
        {
            //throw new NotImplementedException();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            loggerFactory.CreateLogger("Debug");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstoqueWeb v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}