using SiteQuestao.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<VotacaoProducer>();
builder.Services.AddControllersWithViews();

if (!String.IsNullOrWhiteSpace(builder.Configuration["ApplicationInsights:InstrumentationKey"]))
    builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();