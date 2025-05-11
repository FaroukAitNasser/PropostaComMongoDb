using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyApiProject.Models;

public class Pessoa
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool EstaAtivo { get; set; }
    public List<Telefone> Telefones { get; set; } = new();
}
