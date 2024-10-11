using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO;
using TodoApi.Extensions;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Services;

public class BeerService : IBeerService
{

    
    private readonly IRepository<Beer> _beerRepository;
    public BeerService(IRepository<Beer> beerRepository)
    {
        _beerRepository = beerRepository;
    }
    public async Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO)
    {
        var beer = beerInsertDTO.ToModel();

        await _beerRepository.Add(beer);
        await _beerRepository.Save();

        return beer.ToDTO();
    }

    public async Task<BeerDTO> Delete(int id)
    {
        var beer = await _beerRepository.GetById(id);
        if (beer is not null)
        {
            // _context.Beers.Remove(beer);
            // await _context.SaveChangesAsync();
            _beerRepository.Delete(beer);
            await _beerRepository.Save();

            return beer.ToDTO();
        }


        return null!;
    }
    public async Task<IEnumerable<BeerDTO>> Get()
    {
        var results = await _beerRepository.Get();
        return results.Select(b => b.ToDTO());
    }

    public async Task<BeerDTO> GetById(int id)
    {
        var beer = await _beerRepository.GetById(id);

        if (beer is not null)
        {
            return beer.ToDTO();
        }

        return null!;
    }

    public async Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO)
    {
        var beer = await _beerRepository.GetById(id);

        if (beer is not null)
        {
            beer.Name = beerUpdateDTO.Name;
            beer.Alcohol = beerUpdateDTO.Alcohol;
            beer.BrandID = beerUpdateDTO.BrandID;
            _beerRepository.Update(beer);
            await _beerRepository.Save();

            return beer.ToDTO();
        }

        return null!;
    }
}
