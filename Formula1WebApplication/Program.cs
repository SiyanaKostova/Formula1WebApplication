using Formula1WebApplication.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "NewsArticle Details",
        pattern: "/NewsArticle/Details/{id}/{information}",
        defaults: new { Controller = "NewsArticle", Action = "Details" }
    );

    endpoints.MapControllerRoute(
    name: "Event Details",
    pattern: "/Event/Details/{id}/{information}",
    defaults: new { Controller = "Event", Action = "Details" }
    );

    endpoints.MapControllerRoute(
    name: "Race Details",
    pattern: "/Race/Details/{id}/{information}",
    defaults: new { Controller = "Race", Action = "Details" }
    );

    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.CreateAdminRoleAsync();

await app.RunAsync();