using Prestamos.Services;
using Prestamos.Services.Repositories;
using Stock.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

SqliteHandler.ConnectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddSingleton<ILoginRepository, LoginService>();
builder.Services.AddSingleton<ISolicitudRepository, SolicitudService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock.Backend");
    c.RoutePrefix = string.Empty;
});
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.UseAuthentication();
app.Run();