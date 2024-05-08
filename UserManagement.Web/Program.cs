using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Data;
using Westwind.AspNetCore.Markdown;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services
    .AddDataAccess()
    .AddDbContext<DataContext>(options =>
                options.UseSqlServer(@"Data Source=PHIL\MSSQLSERVER10;Initial Catalog=TechTest;Integrated Security=True;Encrypt=False;connect timeout=900;"))
    .AddDomainServices()
    .AddMarkdown()
    .AddControllersWithViews();

var app = builder.Build();

app.UseMarkdown();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization(); 

app.MapDefaultControllerRoute();
app.Run();
