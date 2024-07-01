using DapperRealEstate.Context;
using DapperRealEstate.Services.AgentServices;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyTypeServices;
using DapperRealEstate.Services.PropertyServices;
using DapperRealEstate.Services.TagServices;
using DapperRealEstate.Services.TestimonialServices;
using DapperRealEstate.Services.ImageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    builder.Services.AddScoped<DbContext>();
    builder.Services.AddScoped<IAgentService, AgentService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<ILocationService, LocationService>();
    builder.Services.AddScoped<IPropertyTypeService, PropertyTypeService>();
    builder.Services.AddScoped<IPropertyService, PropertyService>();
    builder.Services.AddScoped<ITagService, TagService>();
    builder.Services.AddScoped<ITestimonialService, TestimonialService>();
    builder.Services.AddScoped<IImageService, ImageService>();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
