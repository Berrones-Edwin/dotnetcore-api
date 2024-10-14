using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repository;

public class BeerRepository : IRepository<Beer>
{
    private readonly Context _context;
    public BeerRepository(Context context)
    {
        _context = context;
    }
    public async Task Add(Beer entity)
    => await _context.Beers.AddAsync(entity);


    public void Delete(Beer entity)
    => _context.Beers.Remove(entity);

    public async Task<IEnumerable<Beer>> Get()
    {
        return await _context.Beers.ToListAsync();
    }

    public async Task<Beer> GetById(int id)
    {
        return await _context.Beers.FindAsync(id);
    }

    public async Task Save()
    => await _context.SaveChangesAsync();


    public void Update(Beer entity)
    {
        _context.Beers.Attach(entity);
        _context.Beers.Entry(entity).State = EntityState.Modified;
    }

    public IEnumerable<Beer> Search(Func<Beer,bool> filter) 
    {
        return _context.Beers.Where(filter).ToList();
    }
}
