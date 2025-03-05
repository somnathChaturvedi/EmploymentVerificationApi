var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin() // Allow requests from any origin
                  .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
                  .AllowAnyHeader(); // Allow any HTTP headers
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

// Enable CORS middleware
app.UseCors("AllowAllOrigins");
app.MapControllers();

app.Run();
