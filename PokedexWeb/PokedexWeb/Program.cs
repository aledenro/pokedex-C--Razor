using PokedexWeb.Data;
using PokedexWeb.Services;
using Microsoft.EntityFrameworkCore;
using PokedexWeb.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("connData");

builder.Services.AddDbContext<ConnectionDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36))));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<PokeApiService>();
builder.Services.AddScoped<TipoService>();
builder.Services.AddScoped<HabilidadService>();
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<PokemonTipoService>();
builder.Services.AddScoped<PokemonHabilidadService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<TipoHelperIntialLoad>();
builder.Services.AddScoped<HabilidadHelperInitialLoad>();
builder.Services.AddScoped<PokemonHelperInitialLoad>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true;
});

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

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
