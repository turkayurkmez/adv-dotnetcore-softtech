using eshop.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    var factory = options.InvalidModelStateResponseFactory;
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var logger = context.HttpContext.RequestServices.GetService<ILogger<Program>>();
                        logger.LogError($"{context.ActionDescriptor.DisplayName} action'unda {context.ModelState.ErrorCount} adet hata oluştu.\nÖzellikler: {string.Join(",", context.ModelState.Keys)}\n hatalar:{string.Join(',', context.ModelState["Name"])} ");

                        return factory(context);
                    };
                });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddInjections(connectionString);
builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
}));

//builder.Services.AddAuthentication("Basic").AddScheme<BasicOption, BasicHandler>("Basic", null);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "softtech.server",
                        ValidAudience = "softtech.client",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-bizim-keyimiz"))
                    };

                });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
