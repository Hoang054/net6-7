using Blazored.LocalStorage;
using CharityClinic.Data;
using CharityClinic.Data.Model;
using CharityClinic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddServerSideBlazor();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IBaseService<NewsDb>, NewsService>();
builder.Services.AddScoped<IBaseService<SuVu>, SuVuService>();
builder.Services.AddScoped<IBaseService<ChamSoc>, ChamSocService>();
builder.Services.AddScoped<IBaseService<DanhMucImage>, DanhMucImageService>();
builder.Services.AddScoped<IBaseService<Image>, ImageService>();
builder.Services.AddScoped<IBaseService<KhamChuaBenh>, KhamChuaBenhService>();
builder.Services.AddScoped<IBaseService<NguoiBenLe>, NguoiBenLeService>();
builder.Services.AddScoped<IBaseService<SucKhoe>, SucKhoeService>();
builder.Services.AddScoped<IBaseService<Video>, VideoService>();
builder.Services.AddScoped<IBaseService<SlideImage>, SlideImageService>();
builder.Services.AddScoped<IBaseService<GioiThieu>, GioiThieuService>();
builder.Services.AddScoped<IBaseService<LichSu>, LichSuService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
