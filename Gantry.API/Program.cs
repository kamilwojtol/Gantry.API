using Gantry.API.Store;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<GantryStore>();
var app = builder.Build();

app.MapControllers();
app.UseRouting();

app.Run();
