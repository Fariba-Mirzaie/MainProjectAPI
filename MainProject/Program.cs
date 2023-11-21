var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddCors(b => b.AddPolicy("MyPolicy", options =>
//options.WithOrigins("https://localhost:7046")
// .AllowAnyMethod()
// .AllowAnyHeader()));


builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("*")
        .AllowCredentials()
        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
        .SetIsOriginAllowed(origin => _ = true);
}));


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

app.UseCors("MyPolicy");

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
