using CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopulateDb.DataAccess;

namespace PopulateDb.Services;

public class BusinessProvider
{
    private readonly BreweryContext _context;
    
    public BusinessProvider(BreweryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BreweryModel>> GetAllBreweries()
    {
        var result = await _context.BreweriesTable.OrderBy(x => x.Id).ToListAsync();
        return result;
    }

    public async Task WriteAllToDb(IEnumerable<BreweryModel> collection)
    {
        Console.WriteLine(collection.Count());
        foreach (var brew in collection)
        {
            var check = await _context.BreweriesTable.Where(b => b.Id == brew.Id).Select(b => b.Id).SingleOrDefaultAsync();
            await _context.BreweriesTable.AddAsync(brew);
            await _context.SaveChangesAsync();
        }
    }
}