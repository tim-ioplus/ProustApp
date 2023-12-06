using ProustApp.Domain;
using ProustApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => {options.RespectBrowserAcceptHeader = true; });

// Add Db Service
builder.Services.Configure<QuestStoreDatabaseSettings>(
    builder.Configuration.GetSection("QuestStoreDatabase"));
builder.Services.AddSingleton<QuestsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
