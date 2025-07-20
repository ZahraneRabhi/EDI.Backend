using EDI.Backend.Contracts;
using EDI.Backend.Data;
using EDI.Backend.Repositories;
using EDI.Backend.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSqlServer<EdiDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IDBCRepository, DBCRepository>();

// OCR Service Configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOCRContract, OCRService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Theme = ScalarTheme.Mars;
    });
}
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
