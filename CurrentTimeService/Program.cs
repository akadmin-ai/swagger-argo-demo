var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrentTimeService API");
});

// Serve a simple website
app.MapGet("/home", async context =>
{
    var htmlContent = @"
    <html>
    <head><title>Current Time Service</title></head>
    <body>
        <h1>Welcome to the Current Time Service</h1>
        <p>Explore the API via <a href='/swagger'>Swagger UI</a>.</p>
        <p>Available Endpoints:</p>
        <ul>
            <li><a href='/time/utc'>Get Current UTC Time</a></li>
            <li><a href='/time/pst'>Get Current PST Time</a></li>
        </ul>
    </body>
    </html>";
    await context.Response.WriteAsync(htmlContent);
});

// API Endpoints
app.MapGet("time/utc", () => Results.Ok(DateTime.UtcNow));

app.MapGet("time/pst", () =>
{
    var pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    var pstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, pstTimeZone);
    return Results.Ok(pstTime);
});

await app.RunAsync();
