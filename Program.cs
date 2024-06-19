using AllBuyMyself;
using AllBuyMyself.Services.Authentication;
using AllBuyMyself.Services.Shopping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AllBuyMyselfDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:AllBuyMyselfDbConnection"))
);
builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => {
            policy.WithOrigins("http://localhost:4200")
                .WithOrigins("http://localhost/")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ShoppingService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<SaveService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}"
);

app.Run();
