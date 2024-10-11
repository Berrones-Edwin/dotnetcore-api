using System;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class Context:DbContext
{
    public Context()
    {
        
    }
    public Context(DbContextOptions<Context> options):base(options)
    {

    }

     public DbSet<TodoItem> TodoItems { get; set; } = null!;
     public DbSet<Brand> Brands { get; set; } = null!;
     public DbSet<Beer> Beers { get; set; } = null!;

}
