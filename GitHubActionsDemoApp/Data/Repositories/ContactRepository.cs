using GitHubActionsDemoApp.Data.Models;
using GitHubActionsDemoApp.Helpers;
using GitHubActionsDemoApp.Interfaces;
using SQLite;

namespace GitHubActionsDemoApp.Data.Repositories;

public class ContactRepository : IRepository<DemoContact>
{

    private SQLiteAsyncConnection? database;

    private async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<DemoContact>();
    }

    public async Task AddAsync(DemoContact entity)
    {
        await Init();
        await database!.InsertAsync(entity);
    }

    public async Task<List<DemoContact>> GetAllAsync()
    {
        await Init();
        return await database!.Table<DemoContact>().ToListAsync();
    }

    public async Task<DemoContact> GetByIdAsync(int id)
    {
        await Init();
        return await database!.Table<DemoContact>().FirstOrDefaultAsync(c => c.Id == id) 
               ?? throw new KeyNotFoundException($"Contact with ID {id} not found.");
    }

    public async Task UpdateAsync(DemoContact entity)
    {
        await Init();
        var existingContact = await GetByIdAsync(entity.Id);
        if (existingContact == null)
        {
            throw new KeyNotFoundException($"Contact with ID {entity.Id} not found");
        }
        await database!.UpdateAsync(entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        await Init();
        return await database!.DeleteAsync<DemoContact>(id);
    }
}