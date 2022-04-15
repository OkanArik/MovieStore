using AutoMapper;
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Entities;
using WebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using WebApi.Applications.MovieOperations.Queries.GetMovies;
using WebApi.Applications.MovieOperations.Queries.GetActors;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using System.Linq;
using WebApi.Applications.DirectorOperations.Queries.GetDirectors;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie,MoiveDetailViewModel>()
                                                  .ForMember(dst=> dst.Genre, opt=> opt.MapFrom(src=> src.Genre.Name))
                                                  .ForMember(dst=> dst.Director, opt=> opt.MapFrom(src=> (src.Director.FullName)))
                                                  .ForMember(dst=> dst.PublisDate, opt=> opt.MapFrom(src=> (src.PublisDate.Date.ToString("dd-MM-yyyy"))))
                                                  .ForMember(dst=> dst.ActorName, opt=> opt 
                                                                                        .MapFrom(x=> x.MovieActors.Select(x=> x.Actor.Fullname).ToList()));
                                                  //.ForMember(dst=> dst.ActorName, opt=> opt.MapFrom(src=> src.Actor.Fullname));
                                                  
                                                  
            CreateMap<Movie,MoivesViewModel>()
                                                  .ForMember(dst=> dst.Genre, opt=> opt.MapFrom(src=> src.Genre.Name))
                                                  .ForMember(dst=> dst.Director, opt=> opt.MapFrom(src=> (src.Director.FullName)))
                                                  .ForMember(dst=> dst.PublisDate, opt=> opt.MapFrom(src=> (src.PublisDate.Date.ToString("dd-MM-yyyy"))))
                                                  .ForMember(dst=> dst.ActorName, opt=> opt 
                                                                                        .MapFrom(x=> x.MovieActors.Select(x=> x.Actor.Fullname).ToList()));
                                                  //opt.MapFrom(src=> src.Actor.Fullname))

            CreateMap<Actor,ActorsViewModel>()
                                                  .ForMember(dst=> dst.Birthday, opt=> opt.MapFrom(src=> src.Birthday.Date.ToString("dd-MM-yyyy")))
                                                  .ForMember(dst=> dst.ActorMovies, opt=> opt 
                                                                                        .MapFrom(x=> x.MovieActors.Select(x=> x.Movie.MovieName).ToList()));
            CreateMap<Actor,ActorDetailViewModel>()
                                                  .ForMember(dst=> dst.Birthday, opt=> opt.MapFrom(src=> src.Birthday.Date.ToString("dd-MM-yyyy")))
                                                  .ForMember(dst=> dst.ActorMovies, opt=> opt 
                                                                                        .MapFrom(x=> x.MovieActors.Select(x=> x.Movie.MovieName).ToList()));
            CreateMap<CreateActorModel,Actor>();
                                                  
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>(); 
            CreateMap<CreateGenreModel,Genre>();

            CreateMap<Director,DirectorsViewModel>()
                                                    .ForMember(dst=> dst.BirthDay, opt=> opt.MapFrom(src=> src.BirthDay.Date.ToString("dd-MM-yyyy")))
                                                    .ForMember(dst=> dst.Movies, opt=> opt 
                                                                                        .MapFrom(x=> x.DirectorMovies.Select(x=> x.MovieName).ToList()));
            CreateMap<Director,DirectorViewModel>()
                                                    .ForMember(dst=> dst.BirthDay, opt=> opt.MapFrom(src=> src.BirthDay.Date.ToString("dd-MM-yyyy")))
                                                    .ForMember(dst=> dst.DirectorMovies, opt=> opt 
                                                                                        .MapFrom(x=> x.DirectorMovies.Select(x=> x.MovieName).ToList()));
            CreateMap<CreateDirectorModel,Director>();
                                                  
        }
    }
}