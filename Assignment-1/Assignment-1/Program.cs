using Assignment_1.Confguration;
using Assignment_1.Context;
using Assignment_1.Repository.AccountRepositoy;
using Assignment_1.Repository.CategoryRepository;
using Assignment_1.Repository.ProductRepository;
using Assignment_1.Service.AccountService;
using Assignment_1.Service.CategoryService;
using Assignment_1.Service.ProductService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string con = builder.Configuration.GetConnectionString("LocalConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(con));
//Category Register
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//Product Register
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
//Account Register
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
//Register Mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));
//Register Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
