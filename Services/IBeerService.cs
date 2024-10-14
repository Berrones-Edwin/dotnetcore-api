using System;
using TodoApi.DTO;

namespace TodoApi.Services;

public interface IBeerService
{

    public List<string> Errors { get; }
    Task<IEnumerable<BeerDTO>> Get();
    Task<BeerDTO> GetById(int id);
    Task<BeerDTO> Add(BeerInsertDTO beerInsertDTO);
    Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDTO);
    Task<BeerDTO> Delete(int id);

    bool Validate(BeerInsertDTO beerInsertDTO);
    bool Validate(BeerUpdateDTO beerUpdateDTO);
}

