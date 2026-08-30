using Gantry.API.Store;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddSingleton<GantryStore>();

var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.UseCors("Frontend");

app.Run();
