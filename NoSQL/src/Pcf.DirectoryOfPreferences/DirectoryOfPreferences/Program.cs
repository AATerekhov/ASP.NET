using DirectoryOfPreferences;
using DirectoryOfPreferences.Application.Implementations.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddMvcOptions(x => x.SuppressAsyncSuffixInActionNames = false);

builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(Program), typeof(PreferenceMapping));

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "PromoCode Factory Directory Of Preference API Doc";
    options.Version = "1.0";
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseOpenApi();
app.UseSwaggerUi(x =>
{
    x.DocExpansion = "list";
});

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();