using BangazonBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using bangazonBE.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonBEDbContext>(builder.Configuration["BangazonBEDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//LOGIN
app.MapGet("/api/checkuser/{uid}", (BangazonBEDbContext db, string uid) =>
{
    var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
    if (authUser == null)
    {
        return Results.StatusCode(204);
    }
    return Results.Ok(authUser);
});

app.Run();


//Users
app.MapGet("/api/users", (BangazonBEDbContext db) =>
{
    return db.Users.ToList();
});


//Register User
app.MapPost("/api/users", (BangazonBEDbContext db, User userInfo) =>
{
    db.Users.Add(userInfo);
    db.SaveChanges();
    return Results.Created($"/api/users/{userInfo.Id}", userInfo);
});

//Check User
app.MapGet("/api/users/{id}", (BangazonBEDbContext db, int id) =>
{
    User user = db.Users.SingleOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

//Get User Details
app.MapGet("/api/users/details/{uid}", (BangazonBEDbContext db, string uid) =>
{

    User user = db.Users.SingleOrDefault(u => u.Uid == uid);

    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);
});

//Switch User to Seller
app.MapPatch("/api/users/sell/{uid}", async (BangazonBEDbContext db, string uid) =>
{
    User user = db.Users.SingleOrDefault(u => u.Uid == uid);

    if (user == null)
    {
        return Results.NotFound();
    }

    user.Seller = true;
    await db.SaveChangesAsync();

    return Results.Ok(user);
});


//Update User
app.MapPatch("/api/users/{id}", (BangazonBEDbContext db, int id, User user) =>
{
    User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    userToUpdate.Uid = user.Uid;
    userToUpdate.FirstName = user.FirstName;
    userToUpdate.LastName = user.LastName;
    userToUpdate.UserName = user.UserName;
    userToUpdate.Address = user.Address;
    userToUpdate.Email = user.Email;
    userToUpdate.Seller = user.Seller;
    db.SaveChanges();
    return Results.Ok(userToUpdate);
});

//Products
//Get All Products
app.MapGet("/api/products", (BangazonBEDbContext db) =>
{
    return db.Products.Include(p => p.ProductType).ToList();
});


//Get Single Product
app.MapGet("/api/products/{id}", (BangazonBEDbContext db, int id) =>
{
    Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

//Create Products
app.MapPost("/api/products", (BangazonBEDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/products/{product.ProductId}", product);
});

//ORDERS
//Get All Orders
app.MapGet("/api/orders", (BangazonBEDbContext db) =>
{
    // Include PaymentType to retrieve related information
    return db.Orders.Include(o => o.PaymentType).ToList();
});

//Get Order Products
app.MapGet("/api/orders/{orderId}/products", (BangazonBEDbContext db, int orderId) =>
{
    var Order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);
    return Order;
});

//Delete Order
app.MapDelete("/api/orders/{orderId}", (BangazonBEDbContext db, int orderId) =>
{
    Order orderToDelete = db.Orders.SingleOrDefault(p => p.OrderId == orderId);
    if (orderToDelete == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(orderToDelete);
    db.SaveChanges();
    return Results.Ok(db.Orders);
});

//ORDERPRODUCT
//Add Product to Order
app.MapPost("api/orders/addProduct", (BangazonBEDbContext db, addProductDTO newProduct) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == newProduct.OrderId);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    var product = db.Products.Find(newProduct.ProductId);

    if (product == null)
    {
        return Results.NotFound("Product not found.");
    }

    var existingProduct = order.Products.FirstOrDefault(p => p.ProductId == newProduct.ProductId);

    if (existingProduct != null)
    {
        existingProduct.Quantity += newProduct.Quantity;
    }
    else
    {
        product.Quantity = newProduct.Quantity;
        order.Products.Add(product);
    }

    db.SaveChanges();

    return Results.Created($"/orders/addProduct", newProduct);
});

//Get Product Orders By Id
app.MapGet("/api/products/{orderId}/orders", (BangazonBEDbContext db, int id) =>
{
    var product = db.Products.Include(p => p.Orders).FirstOrDefault(p => p.ProductId == id);
    return product;
});

//Remove Product From Order
app.MapDelete("/api/orders/{orderId}/products/{productId}", (BangazonBEDbContext db, int orderId, int productId) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    var productToRemove = order.Products.FirstOrDefault(p => p.ProductId == productId);

    if (productToRemove == null)
    {
        return Results.NotFound("Product not found in cart.");
    }

    order.Products.Remove(productToRemove);

    db.SaveChanges();

    return Results.Ok("Product removed from the cart.");
});

//PRODUCT TYPES
//Get All Product Types
app.MapGet("/api/producttypes", (BangazonBEDbContext db) =>
{
    return db.ProductTypes.ToList();
});

//Get Product Type by Id
app.MapGet("/api/producttypes/{id}", (BangazonBEDbContext db, int id) =>
{
    ProductType producttype = db.ProductTypes.SingleOrDefault(pt => pt.Id == id);
    if (producttype == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(producttype);
});


