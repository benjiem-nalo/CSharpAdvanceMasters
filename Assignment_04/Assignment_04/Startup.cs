using Assignment_04.DAL;
using Assignment_04.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment_04
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VideoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<VideoDbContextInitialiser>();
            services.AddScoped<IVideosDAL, VideosDAL>();
            services.AddTransient<IVideoService, VideoService>();
        }
    }


}
