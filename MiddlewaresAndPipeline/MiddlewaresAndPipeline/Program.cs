var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<<<<<<");
    await next();
    await context.Response.WriteAsync(">>>>>>");

});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("--------");
    await next();
    await context.Response.WriteAsync("++++++++");
});

app.Run(async context => await context.Response.WriteAsync("Response generated"));

// Configure the HTTP request pipeline.
//app.UseWelcomePage();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();
//app.UseC

//app.MapControllers();

app.Run();
