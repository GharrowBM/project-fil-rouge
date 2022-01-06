using FilRouge.Classes;
using FilRouge.Repositories;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FilRouge.API.Services;

namespace FilRouge.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilRouge.API", Version = "v1" });
            });
            services.AddDbContext<DataContext>();
            services.AddScoped<IRepository<Answer>, AnswerRepository>();
            services.AddScoped<IRepository<Comment>, CommentRepository>();
            services.AddScoped<IRepository<Post>, PostRepository>();
            services.AddScoped<IRepository<Tag>, TagRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<UploadService>();

            services.AddCors(options => {
                options.AddPolicy("allConnections", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });

                options.AddPolicy("react", builder =>
                {
                    builder.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour, je suis la clé de cryptage!")),
                    ValidateIssuer = true,
                    ValidIssuer = "m2i",
                    ValidateAudience = true,
                    ValidAudience = "m2i"
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", police =>
                {
                    police.RequireClaim(ClaimTypes.Role, "admin");
                    //police.RequireClaim(ClaimTypes.Role, "admin");

                });
                options.AddPolicy("user", police =>
                {
                    police.RequireClaim(ClaimTypes.Role, "user");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilRouge.API v1"));
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
