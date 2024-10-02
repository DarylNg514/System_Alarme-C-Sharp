var builder = WebApplication.CreateBuilder(args);
// Configure Kestrel and listen on port 5089
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5089); // Or use Listen(IPAddress.Parse("10.1.8.218"), 5089)
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
