using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;
using OOPVotingSystem.DAL;
using OOPVotingSystem.Repositories;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service;
using OOPVotingSystem.Service.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services
    .AddDbContext<PersonContext>(op => op = op.UseSqlite("DataSource=oop.db"))
    .AddDbContext<AddressContext>(op => op = op.UseSqlite("DataSource=oop.db"))
    .AddDbContext<MoneyContext>(op => op = op.UseSqlite("DataSource=oop.db"))
    .AddDbContext<VoteContext>(op => op = op.UseSqlite("DataSource=oop.db"))
    .AddDbContext<PartyContext>(op => op = op.UseSqlite("DataSource=oop.db"))
    .AddDbContext<UserContext>(op => op.UseSqlite("DataSource=oop.db"));

builder.Services
    .AddScoped<IPartyRepository, PartyRepository>()
    .AddScoped<IPersonRepository, PersonRepository>()
    .AddScoped<IVoteRepository, VoteRepository>();

builder.Services
    .AddScoped<IUserService, UserService>();

builder.Services
    .AddBlazorise(options => options.Immediate = true)
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
