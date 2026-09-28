using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<HotelManagementSystem.Repositories.IFloorRepository, HotelManagementSystem.Repositories.FloorRepository>();
builder.Services.AddScoped<HotelManagementSystem.Repositories.ICustomerRepository, HotelManagementSystem.Repositories.CustomerRepository>();
builder.Services.AddScoped<HotelManagementSystem.Repositories.IBookingRepository, HotelManagementSystem.Repositories.BookingRepository>();
builder.Services.AddScoped<HotelManagementSystem.Repositories.IRoomRepository, HotelManagementSystem.Repositories.RoomRepository>();
builder.Services.AddScoped(typeof(HotelManagementSystem.Repositories.IBaseRepository<>), typeof(HotelManagementSystem.Repositories.BaseRepository<>));
builder.Services.AddScoped<HotelManagementSystem.Repositories.IUserRepository, HotelManagementSystem.Repositories.UserRepository>();





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
