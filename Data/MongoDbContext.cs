using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyApiProject.Models;

namespace MyApiProject.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(config["MongoDB:Database"]);
    }

    public IMongoCollection<Pessoa> Pessoas => _database.GetCollection<Pessoa>("Pessoas");
}