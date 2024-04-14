using APITraining.Data;
using APITraining.Mappings;
using APITraining.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using Serilog;
using APITraining.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //inject logger here
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/NzWalks_Log.txt", rollingInterval: RollingInterval.Minute)
            //.MinimumLevel.Information()
            .MinimumLevel.Warning()
            .CreateLogger();
        builder.Logging.ClearProviders(); //FIRST CLEAR ANYOTHER LOGGING
        builder.Logging.AddSerilog(logger);

        builder.Services.AddHttpContextAccessor();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TJTechy Walks API",
                Version = "v1"
            });
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        },
                        Scheme = "Oauth2",
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        //inject the db context classes here
        builder.Services.AddDbContext<NZWalksDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

        builder.Services.AddDbContext<NZWalksAuthDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksAuthConnectionString")));

        //inject the IRegionRepository and its implementation here
        builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

        //builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

        //inject the IWalkRepository and its implementation here
        builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

        //inject the token repository here
        builder.Services.AddScoped<ITokenRepository, TokenRepository>();

        //inject Image Repo
        builder.Services.AddScoped<IImageRepository, LocalImageRepository>();

        //inject the automapper here
        builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

       

        //add identity solution here
        builder.Services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks")
            .AddEntityFrameworkStores<NZWalksAuthDBContext>()
            .AddDefaultTokenProviders();
        //access the identity options
        builder.Services.Configure<IdentityOptions>(options =>
        {
            //for example how many digits password, upper case, lower case length etc
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        }
        );

        //add authentication here to the services
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt: Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //inject the middle ware here
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        //to be able to open the image file in url
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
            RequestPath = "/Images"
            //https://Localhost:1234/Images
        });

        app.MapControllers();

        app.Run();
    }
}

/*add the following nugget package:
 * Microsoft.entityframeworkcore.sqlserver
 * entityFrameworkcore.tools: for database migration, creation etc
 * db
 * 
 */