using Azure.Storage.Blobs;
using BlobStorageTest.Service;
using BlobStorageTest.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(blob => 
new BlobContainerClient(
    builder.Configuration.GetConnectionString("BlobStorage"), 
    builder.Configuration.GetSection("BlobStorageName").Get<string>()
    ));
builder.Services.AddScoped<IBlobService, BlobService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
