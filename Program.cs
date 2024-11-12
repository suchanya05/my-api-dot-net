using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// เพิ่มการเชื่อมต่อกับ PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ลงทะเบียน Repository และ Service
builder.Services.AddScoped<PersonalRepository>();
builder.Services.AddScoped<PersonalService>();

builder.WebHost.UseUrls("http://localhost:8080");

// เพิ่มบริการ MVC
builder.Services.AddControllersWithViews();

// กำหนดนโยบาย CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("*") // แทนที่ด้วย URL ของ Frontend ของคุณ
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin"); // ใช้นโยบาย CORS ที่กำหนดไว้

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Personal}/{action=Index}/{id?}");

app.Run();
