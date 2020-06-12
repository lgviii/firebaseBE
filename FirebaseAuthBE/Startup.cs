using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Counter;
using Counter.Services;
using Counter.Models;
using Counter.Mongo;

namespace FirebaseAuthBE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true;
                    options.Authority = "https://securetoken.google.com/reactauth-f1c98";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/reactauth-f1c98",
                        ValidateAudience = true,
                        ValidAudience = "reactauth-f1c98",
                        ValidateLifetime = true
                    };
                });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            // Add services here
            services.AddTransient<ICounterService, CounterService>();
            services.AddScoped<ICounterRepository, CounterRepository>();
            services.AddTransient<ICounterContext, CounterContext>();

            services.AddControllers();

            services.Configure<MongoSettings>(
               options =>
               {
                   options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                   options.Database = Configuration.GetSection("MongoDb:Database").Value;
               });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
