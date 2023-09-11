using MiddlewaresAndPipeline.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//hazır middleware:

//app.UseWelcomePage();
//Örnek middleware 1:


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("<<<<<<");
//    await next();
//    await context.Response.WriteAsync(">>>>>>");

//});

//Örnek middleware 2:


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("--------");
//    await next();
//    await context.Response.WriteAsync("++++++++");
//});

//app.Run(async context => await context.Response.WriteAsync("Response generated"));

// Configure the HTTP request pipeline.
//app.UseWelcomePage();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Gelen request post ise ve JSON verisi içeriyorsa:
// 1. Bu JSON Verisini ayır ve sonraki middleware gönder
// 2. Gelen veri içinde istenmeyen kelime varsa bad request döndür.


app.UseHttpsRedirection();

app.UseMiddleware<JSONIsolateMiddleware>();
app.UseMiddleware<BadwordsFilterMiddleware>();

app.UseAuthorization();


app.MapControllers();

app.Run();
