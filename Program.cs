using System.Threading.RateLimiting;
using AlkitabAPI.Services;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();


//add rate limit
builder.Services.AddRateLimiter(_ =>
_.AddFixedWindowLimiter(policyName:"fixed", options =>
{
    options.PermitLimit = 4;
    options.Window = TimeSpan.FromSeconds(10);
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    options.QueueLimit = 5;
}));

//implement interface 261122
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IPassageService, PassageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

app.Run();