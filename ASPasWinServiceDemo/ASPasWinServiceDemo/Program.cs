var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Host.UseWindowsService();
var app = builder.Build();
app.MapControllers();

app.Run();
