using DigitalDialogueHub.Data; // Samo jednom, koristiš ApplicationDbContext iz ovog namespace-a
using Microsoft.EntityFrameworkCore; // Za Entity Framework Core
using System.Net; // Za ServicePointManager

var builder = WebApplication.CreateBuilder(args);

// Dodaj TLS 1.2 pre nego što bilo šta krene
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Omogućava korišćenje TLS 1.2 za sigurnu komunikaciju

// Dodaj konekciju sa SQL Serverom
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj servise za controllers, Swagger, itd.
builder.Services.AddControllers(); // Registruješ kontrolere za API
builder.Services.AddEndpointsApiExplorer(); // Omogućava automatsko generisanje dokumentacije
builder.Services.AddSwaggerGen(); // Dodaje Swagger generaciju za API dokumentaciju

var app = builder.Build();

// Middleware - Postavke koje se primenjuju na aplikaciju
if (app.Environment.IsDevelopment()) // Ako je aplikacija u razvoju
{
    app.UseSwagger(); // Omogućava generisanje Swagger dokumentacije
    app.UseSwaggerUI(); // Omogućava interaktivni UI za testiranje API-ja
}

app.UseHttpsRedirection(); // Preusmerava sve HTTP zahteve na HTTPS
app.UseAuthorization(); // Omogućava autentifikaciju i autorizaciju
app.MapControllers(); // Mapira sve kontrolere sa HTTP metodama
app.Run(); // Pokreće aplikaciju
