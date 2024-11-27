using GithubUserActivityTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddHttpClient<GitHubService>(); // Register the GitHubService
builder.Services.AddControllers();              // Add controllers

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed error pages in development
}

app.UseHttpsRedirection();          // Redirect HTTP to HTTPS
app.UseRouting();                   // Enable routing

// Map controller endpoints
app.MapControllers();

// Run the application
app.Run();