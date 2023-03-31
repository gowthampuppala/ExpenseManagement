using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTUzMDQ0M0AzMjMxMmUzMTJlMzMzNWxRVGNHdGpsQXlqYzgwYlJicmVUbHlYbUZhT0FJclZxY1pOb2pScDJVdDQ9;Mgo+DSMBaFt+QHFqVkNrWE5BaV1CX2BZe1lyTGlafk4BCV5EYF5SRHVdS11mTXdQd01iWnw=;Mgo+DSMBMAY9C3t2VFhhQlJBfVtdWHxLflF1VWZTe1d6d1RWESFaRnZdQV1gS3dTc0FqWn5Wc3BW;Mgo+DSMBPh8sVXJ1S0d+X1RPckBHQmFJfFBmQGlddlRzdUU3HVdTRHRcQl5hQH5WckxgWHdbdnc=;MTUzMDQ0N0AzMjMxMmUzMTJlMzMzNURiZmJINEsraWFqVy80ZkswK2UycnM3QWRWVENBUCtYYlJwc05EQ1ZGQzA9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RGQmZWfFN0RnNcdVp5flZHcC0sT3RfQF5jSnxadkBnUHxfeH1RRQ==;ORg4AjUWIQA/Gnt2VFhhQlJBfVtdWHxLflF1VWZTe1d6d1RWESFaRnZdQV1gS3dTc0FqWn5XcH1W;MTUzMDQ1MEAzMjMxMmUzMTJlMzMzNVFsS3FIQ29xR1RRMTlNVDhWai9OaHVxQUJZZkh2UEJWUWpYbjhJYnlkeFU9;MTUzMDQ1MUAzMjMxMmUzMTJlMzMzNVo4RkJLL1lVaVhWRGphSkVlaXpJWlN5YUNvWDIvLzlzZG9oYXFGSzRtZFE9;MTUzMDQ1MkAzMjMxMmUzMTJlMzMzNU5JeXUwanMvRkZnU3l3S0ZNdTkxVDNzQ2NnYTM0NFk4aGFBMWdjb25zZXM9;MTUzMDQ1M0AzMjMxMmUzMTJlMzMzNU1xRUlPalNEVHduSisvdmwxWHFORGZyYXJVK2YvMnpjSmx6LytZQitONzQ9;MTUzMDQ1NEAzMjMxMmUzMTJlMzMzNWxRVGNHdGpsQXlqYzgwYlJicmVUbHlYbUZhT0FJclZxY1pOb2pScDJVdDQ9");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
