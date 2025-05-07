using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework Core
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS (permite solicitudes desde tu frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3000") // Reemplaza con la URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Necesario si usas cookies o autenticación
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS (¡Debe estar antes de UseAuthorization y MapControllers!)
app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();
app.Run();