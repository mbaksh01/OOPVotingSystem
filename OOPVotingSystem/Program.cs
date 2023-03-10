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
    .AddDbContext<Database>(op => op = op.UseSqlite("DataSource=oop.db"));

builder.Services
    .AddScoped<IElectionRepository, ElectionRepository>()
    .AddScoped<IPartyRepository, PartyRepository>()
    .AddScoped<IPersonRepository, PersonRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IRepository<OOPVotingSystem.Models.Address>, AddressRepository>()
    .AddScoped<IVoteRepository, VoteRepository>();

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IPartyService, PartyService>();

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
