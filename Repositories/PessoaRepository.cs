using MongoDB.Driver;
using MyApiProject.Models;
using MyApiProject.Data;

namespace MyApiProject.Repositories;

public class PessoaRepository
{
    private readonly IMongoCollection<Pessoa> _pessoas;

    public PessoaRepository(MongoDbContext context)
    {
        _pessoas = context.Pessoas;
    }

    public async Task<List<Pessoa>> GetAllAsync() =>
        await _pessoas.Find(_ => true).ToListAsync();

    public async Task<Pessoa?> GetByIdAsync(string id) =>
        await _pessoas.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pessoa pessoa) =>
        await _pessoas.InsertOneAsync(pessoa);

    public async Task UpdateAsync(string id, Pessoa pessoa) =>
        await _pessoas.ReplaceOneAsync(p => p.Id == id, pessoa);

    public async Task DeleteAsync(string id) =>
        await _pessoas.DeleteOneAsync(p => p.Id == id);
}
