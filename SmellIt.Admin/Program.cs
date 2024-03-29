using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Options;
using SmellIt.Admin.Services;
using SmellIt.Application.Extensions;
using SmellIt.Infrastructure.Extensions;
using SmellIt.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Configuration.AddUserSecrets<Program>();

// Add db
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication(builder.Configuration);

// Add multi languages
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
	.AddViewLocalization()
	.AddDataAnnotationsLocalization(options =>
	{
		options.DataAnnotationLocalizerProvider = (type, factory) =>
		{
			var assemblyName = new AssemblyName(typeof(Resource).GetTypeInfo().Assembly.FullName!);
			return factory.Create("ShareResource", assemblyName.Name!);
		};
	});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new List<CultureInfo>
	{
		new CultureInfo("pl-PL"),
		new CultureInfo("en-GB")
	};

	options.DefaultRequestCulture = new RequestCulture(culture: "pl-PL", uiCulture: "pl-PL");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;

	options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions!.Value);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
