using PruebaTecnicaSentry.Data;
using PruebaTecnicaSentry.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddTransient<IRepository, TareaData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseCors(_cors => {
    _cors.AllowAnyOrigin();
    _cors.AllowAnyMethod();
    _cors.AllowAnyHeader();
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
