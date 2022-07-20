//Program.cs is the only file that uses top-level statements
//This file will really launch the application as a console application 

/* WebApplication.CreateBuilder makes sure that the app at startup looks at
* the appsettings.json and loads the settings from that file
* It will also make sure that Kestrelis inclided and set up IS integration 
* Another default applied by CreateBuilder is that the wwwroot folder will the 
* folder to contain static content 
*/
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Let's add in a service here

//Register ourown services: ICategoryRepository and IPieRepository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

//builder has access to Servecies collections
//AddControlersWithViews will make sure that our application knows about ASP.NET Core MVC
builder.Services.AddControllersWithViews();


//Register the DbContext
builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

//This app instance can be used to bring in multiple middleware components
var app = builder.Build();

/*Midddelware components build up what is known as the middleware request pipeline
* By defualt MapGet is a middelware component tha listens
* for an incoming request to the root of the app "/" and then return Hello World
* At this point: send a GET, gte back Hello World
* app.MapGet("/", () => "Hello World!");
* */

//Add a middleware component
app.UseStaticFiles(); //It looks for incoming requests for static files (JPEG, CSS file)

//Anothe middleware to see errors inside the executing application, 
// It must be used development enviroment, not production or staging 

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Middleware to have the ability to be able to navigate to our pages (views),
// to in fact make sure that ASP.NET Core will be able to handle incoming requests correctly
// This is an endpoint middleware so it must be placed at the end
app.MapDefaultControllerRoute();

//Call the DbInitializer.Seed
DbInitializer.Seed(app);

//This will start our application 
app.Run();
