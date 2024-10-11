using System;
using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Extensions;

public static class BeerExtensions
{
    public static BeerDTO ToDTO(this Beer beer)
    {
        var beerDTO = new BeerDTO
        {
            Id = beer.BeerId,
            Name = beer.Name,
            BrandID = beer.BrandID,
            Alcohol = beer.Alcohol
        };
        return beerDTO;
    }

    public static Beer ToModel(this BeerInsertDTO beerInsertDTO)
    {
        var beer = new Beer
        {
            Name = beerInsertDTO.Name,
            BrandID = beerInsertDTO.BrandID,
            Alcohol = beerInsertDTO.Alcohol,
        };

        return beer;
    }
}
