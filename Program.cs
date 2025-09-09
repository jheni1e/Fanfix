using Fanfix.Models;
using Fanfix.Services.JWT;

using System.Text;
using Fanfix.UseCases.CreateFanfic;
using Fanfix.UseCases.DeleteFanfic;
using Fanfix.UseCases.EditList;
using Fanfix.UseCases.SearchList;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var strConnection = "Data Source = localhost; Initial Catalog = Fanfix; Trust Server Certificate = true; Integrated Security = true";
builder.Services.AddDbContext<FanfixDbContext>(
    options => options.UseSqlServer(strConnection)
);

builder.Services.AddSingleton<IJWTService, JWTService>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

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

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddTransient<CreateFanficUseCase>();
builder.Services.AddTransient<DeleteFanficUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<SearchListUseCase>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
