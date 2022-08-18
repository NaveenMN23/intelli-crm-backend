//using Microsoft.IdentityModel.Tokens;
//using Ocelot.Authentication.Middleware;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;
//using RitcoAPIGateway.Utility;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//          .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
//          .AddJsonFile("OcelotConfig.json", optional: true, reloadOnChange: true);
//});

//IConfiguration configuration = builder.Configuration;

//builder.Services.AddAuthentication().AddJwtBearer("categories_auth_scheme", options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtTokenSettings:JwtSecretKey"))),
//        ValidAudience = configuration.GetValue<string>("JwtTokenSettings:Audience"),
//        ValidIssuer = configuration.GetValue<string>("JwtTokenSettings:Issuer"),
//        ValidateIssuerSigningKey = true,
//        ValidateLifetime = true,
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ClockSkew = TimeSpan.Zero
//    };

//});

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddOcelot();

//builder.Services.AddCors();

//builder.Services.AddScoped<IJwtUtils, JwtUtils>();
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (builder.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.UseAuthentication();
//app.UseAuthorization();

//app.UseAuthenticationMiddleware();

//app.UseCors(x => x
//    .SetIsOriginAllowed(origin => true)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowCredentials());

////Ocelot

//await app.UseOcelot();
