using Fanfix.Models;
using Fanfix.Services.JWT;

using System.Text;
using Fanfix.UseCases.CreateFanfic;
using Fanfix.UseCases.DeleteFanfic;
using Fanfix.UseCases.EditList;
using Fanfix.UseCases.SearchList;
using Fanfix.Services.Fanfics;
using Fanfix.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Fanfix.UseCases.Login;
using Fanfix.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var strConnection = "Data Source = localhost; Initial Catalog = Fanfix; Trust Server Certificate = true; Integrated Security = true";
builder.Services.AddDbContext<FanfixDbContext>(
    options => options.UseSqlServer(strConnection)
);

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddSingleton<SecurityKey>(key);
builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddScoped<IFanficService, FanficService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "fanfix",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddTransient<CreateFanficUseCase>();
builder.Services.AddTransient<DeleteFanficUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<SearchListUseCase>();
builder.Services.AddTransient<LoginUseCase>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAuthEndpoints();
app.ConfigureUserEndpoints();
app.ConfigureFanficEndpoints();
app.ConfigureReadingListEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
