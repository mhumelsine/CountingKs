using CountingKs.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CountingKs.API
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
            var connection = Configuration.GetConnectionString("CountingKsDB");

            services.AddDbContext<CountingKsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CountingKsDB")));

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<ModelFactory, ModelFactory>((serviceProvider) =>
            {
                var contextAccessor = serviceProvider.GetRequiredService<IActionContextAccessor>();
                var urlHelperFactory = serviceProvider.GetRequiredService<IUrlHelperFactory>();

                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);

                return new ModelFactory(urlHelper);
            });

            services.AddMvc();
            services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CountingKsContext>();
                context.Database.Migrate();
                new CountingKsSeeder(context).Seed();
            }
        }
    }
}
