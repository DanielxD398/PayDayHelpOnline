using PayDayHelpOnline.Models;
using PayDayHelpOnline.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IMenuService, MenuService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
    pattern: "{controller=Home}/{action=Inicio}/{id?}");

app.MapControllerRoute(
    name: "topicRoute",
    pattern: "payday/{controller}/{action}/{subcontroller}/{subaction}/topic={topicName}",
    defaults: new { controller = "PayDay", action = "MenuPrincipal" });


app.Run();
