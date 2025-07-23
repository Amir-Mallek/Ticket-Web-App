using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Ticket_Web_App.IServices;
using Ticket_Web_App.Services;
using TicketApp;

var builder = WebApplication.CreateBuilder(args);

var crmSettings = builder.Configuration.GetSection("CRM").Get<CRMSettings>();
string connectionString = $@"
    AuthType=ClientSecret;
    Url={crmSettings.Url};
    ClientId={crmSettings.ClientId};
    ClientSecret={crmSettings.ClientSecret};
    LoginPrompt=Never;
    TokenCacheStorePath={crmSettings.CachePath};
";

// Add services to the container.
builder.Services.AddSingleton<IOrganizationService>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Attempting to connect to Dynamics CRM...");
    var serviceClient = new ServiceClient(connectionString);
    if (serviceClient.IsReady)
    {
        logger.LogInformation
        (
            "Successfully connected to Dynamics CRM: {orgName}", 
            serviceClient.ConnectedOrgFriendlyName
        );
    }
    else
    {
        logger.LogError("Failed to connect to Dynamics CRM: {Error}", serviceClient.LastError);
        throw new InvalidOperationException($"CRM connection failed: {serviceClient.LastError}");
    }

    return (IOrganizationService)serviceClient;
});
builder.Services.AddScoped<ICrmRepository<Incident>, CrmRepository<Incident>>();
builder.Services.AddScoped<ICrmRepository<Account>, CrmRepository<Account>>();
builder.Services.AddScoped<ICrmRepository<Contact>, CrmRepository<Contact>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

record CRMSettings
{
    public string Url { get; init; }
    public string ClientId { get; init; }
    public string ClientSecret { get; init; }
    public string CachePath { get; init; }
}