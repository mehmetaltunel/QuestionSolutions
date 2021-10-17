using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuestionSolutions.Main.Application.Mapper;
using QuestionSolutions.Main.Domain;
using QuestionSolutions.Main.Infrastructure;
using QuestionSolutions.SharedKernel.Accessors;
using QuestionSolutions.SharedKernel.MediatR.Behaviors;
using QuestionSolutions.SharedKernel.MediatR.ExceptionHandlers;
using QuestionSolutions.SharedKernel.SeedWork;

namespace QuestionSolutions.Main.API
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
            
            services.AddControllers()
                .AddJsonOptions   (options => options.JsonSerializerOptions.IgnoreNullValues = true)
                .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling   = Newtonsoft.Json.NullValueHandling.Ignore );
            //services.AddTransient<UserContextAccessor>();

            services.AddHttpContextAccessor();  

            #region mediatr
            var assemblies = new [] { Assembly.Load("QuestionSolutions.Main.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null") };
            services.AddMediatR                 (assemblies);
            services.AddValidatorsFromAssemblies(assemblies);
            services.AddTransient<IUnitOfWorkFactory<IMainDbContext>, MainUnitOfWorkFactory>();
            services.AddTransient(typeof(IPipelineBehavior       <, >), typeof(ValidationBehavior        <, >));
            services.AddTransient(typeof(IPipelineBehavior       <, >), typeof(RequestBehaviour          <, >));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ValidationExceptionHandler<,,>));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(PostgresExceptionHandler  <,,>));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(UnhandledExceptionHandler <,,>));

            #endregion

            #region mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
            

            #endregion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "QuestionSolutions.Main.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuestionSolutions.Main.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}