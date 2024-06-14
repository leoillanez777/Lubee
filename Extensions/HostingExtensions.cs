using System.Text;
using Lubee.Contexts;
using Lubee.Middlewares;
using Lubee.Models;
using Lubee.Services;
using Lubee.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lubee.Extensions;

internal static class HostingExtensions {
  public static WebApplication ConfigureServices(this WebApplicationBuilder builder) {
    #region CORS
    builder.Services.AddCors(options => {
      options.AddPolicy("AllowSpecificOrigin",
        builderPolicy => {
          builderPolicy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        }
      );
    });
    #endregion

    #region DATABASE
    builder.Services.AddDbContext<Context>(options => 
      options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
      b => b.UseNetTopologySuite())
    );
    #endregion
    
    #region Dependency Inject Service
    builder.Services.AddTransient<TipoOperacionService>();
    builder.Services.AddTransient<TipoPropiedadService>();

    builder.Services.AddScoped<ITiposFactory, TiposFactory>();

    builder.Services.AddTransient<IClasificado, ClasificadoService>();
    builder.Services.AddTransient<IImagenes, ImagenesService>();
    #endregion

    #region AUTOMAPPER
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddControllers();
    #endregion

    #region SWAGGER
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(ConfigureSwaggerAuth);
    #endregion

    #region JWT AUTHENTICATION
    var jwtSetting = new JwtSetting();
    builder.Configuration.GetSection("JWT").Bind(jwtSetting);
    builder.Services.AddAuthentication( options => {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options => ConfigureJwtBearer(options, jwtSetting));

    builder.Services.AddAuthorization();
    #endregion

    return builder.Build();
  }

  public static WebApplication ConfigurePipeline(this WebApplication app) {
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.Use(async (context, next) => {
      context.Request.EnableBuffering();
      await next();
    });

    app.UseCors("AllowSpecificOrigin");

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    return app;
  

  }

  private static void ConfigureSwaggerAuth(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options) {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
      Name = "Authorization",
      Type = SecuritySchemeType.ApiKey,
      Scheme = "Bearer",
      BearerFormat = "JWT",
      In = ParameterLocation.Header,
      Description = "JWT Authorization header using the Bearer scheme.",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
        new OpenApiSecurityScheme {
          Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
          }
        },
        Array.Empty<string>()
      }
    });
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Meddy.API", Version = "1.0.1" });
  }

  private static void ConfigureJwtBearer(JwtBearerOptions options, JwtSetting setting)
  {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters() {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidAudience = setting.Audience,
      ValidIssuer = setting.Issuer,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Key))
    };
  }

}