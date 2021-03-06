using Asp.NetCore5.factory;
using Asp.NetCore5.Middleware;
using Asp.NetCore5.Option;
using Asp.NetCore5.Repasitory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ITransient, Transient>();
            //services.AddScoped<ITransient, Transient>();
            //services.AddSingleton<ITransient, Transient>();
            //services.AddTransient(typeof(IList<>),typeof(List<>));

            //services.AddHttpsRedirection(opts =>
            //{
            //    opts.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    opts.HttpsPort = 443;
            //});

            //services.AddHsts(c =>
            //{
            //    c.MaxAge = TimeSpan.FromDays(1);
            //    c.IncludeSubDomains = true;
            //});

            //var useDistribute = true;
            //services.AddScoped<ICashAdapter>(c =>
            //{
            //    if (useDistribute)
            //        return new InDistributedCash();
            //    return new InMemoryCach();

            //});

            //services.AddDistributedMemoryCache();
            //services.AddSession(c =>
            //{
            //    c.Cookie.IsEssential = true;
            //});

            //services.Configure<CookiePolicyOptions>(c =>
            //{
            //    c.CheckConsentNeeded = context => true;
            //});

            var configuration1 = _configuration["ArashEnviromentVariable"];
            var configuration2 = _configuration["ArashJsonEnviroment"];
            var configuration3 = _configuration["UserSecretTestDate"];

            var personalDataOptions = new PersonalDataOptions();

            _configuration.GetSection("PersonalData").Bind(personalDataOptions);
            services.AddSingleton(personalDataOptions);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PersonalDataOptions personalDataOptions)
        {
            var fName= personalDataOptions.FirstName;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseMiddleware<TransientMiddleware>();
            // app.Use(async (httpContext, next) =>
            //{
            //    if (httpContext.Request.Query.ContainsKey("key"))
            //    {
            //        await httpContext.Response.WriteAsync("key write");
            //    }
            //    await next();
            //});
            //app.UseMiddleware<RequestCultureMiddleware>();

            //app.MapWhen(context => context.Request.Query.ContainsKey("mapwhen"), async c =>
            //{
            //    c.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("mapwhen");
            //    });
            //});
            //app.Map("/admin", c =>
            //{
            //    app.Use(async (httpContext, next) =>
            //    {
            //        await httpContext.Response.WriteAsync("/admin");
            //    });
            //});

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, "statickFile")),
            //    RequestPath = "/new"
            //});
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/statickFile"),
            //    RequestPath = "/new"
            //});

            // Redirection Https
            //app.UseHttpsRedirection();

            // check https
            //app.Use(async (context,next) => {

            //    await context.Response.WriteAsync($"{context.Request.IsHttps}");
            //    await next();
            //});

            //app.UseHsts();

            //app.UseMiddleware<CookieMiddleWare>();
            //app.UseSession();
            //app.UseMiddleware<SessionTestMiddleWare>();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World! \n");
                });
            });
        }
    }
}
