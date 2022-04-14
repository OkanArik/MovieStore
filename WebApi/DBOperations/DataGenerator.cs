using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator 
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Directors.AddRange(
                    new Director{
                        FullName="Frank Darabont",
                        BirthDay=new DateTime(1967,11,09),
                    },
                    new Director{
                        FullName="Francis Ford Coppola",
                        BirthDay=new DateTime(1981,02,23),
                    },
                    new Director{
                        FullName="Robert Zemeckis",
                        BirthDay=new DateTime(1978,03,08),
                    }
                );
                context.Genres.AddRange(
                    new Genre{
                        Name="Drama",
                    },
                    new Genre{
                        Name="Detective",
                    },
                    new Genre{
                        Name="Comedy Drama",
                    }
                );
                context.Actors.AddRange(
                    new Actor{
                        Fullname ="Tim Robbins",
                        Birthday = new DateTime(1958,10,16),

                    },
                    new Actor{
                        Fullname = "Alpacino",
                        Birthday = new DateTime(1944,03,12),

                    },
                    new Actor{
                        Fullname = "Tom Hanks",
                        Birthday = new DateTime(1965,04,09),

                    }
                );
                context.Movies.AddRange(
                    new Movie{
                        MovieName = "The Shawshank Redemption",
                        PublisDate = new DateTime(1995,03,10),
                        DirectorId = 1, // Frank Darabont
                        GenreId = 1 , // Drama
                        ActorId = 1, //Tim Robbins
                        Price = 111,
                    },
                    new Movie{ 
                        MovieName = "The Godfather",
                        PublisDate = new DateTime(1973,10,01),
                        DirectorId = 2, // Francis Ford Coppola
                        GenreId = 2 , // Detective
                        ActorId = 2, //Alpacino
                        Price = 222,
                    },
                    new Movie{ 
                        MovieName = "Forrest Gump",
                        PublisDate = new DateTime(1994,11,11),
                        DirectorId = 3, // Robert Zemeckis
                        GenreId = 3 , // Comedy Drama
                        ActorId = 3 , // Tom Hanks
                        Price = 333,
                    }
                );

                context.SaveChanges();
            } 
        }
    }
}