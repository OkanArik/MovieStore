using System.Collections.Generic;
using AutoMapper;
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Common.Enums;
using WebApi.Entities;
using WebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using WebApi.Applications.MovieOperations.Queries.GetMovies;
using WebApi.Applications.MovieOperations.Queries.GetActors;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.ActorOperations.Commands.CreateActor;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie,MoiveDetailViewModel>()
                                                  .ForMember(dst=> dst.Genre, opt=> opt.MapFrom(src=> (((GenreEnum)src.GenreId).ToString())))
                                                  .ForMember(dst=> dst.Director, opt=> opt.MapFrom(src=> (((DirectorEnum)src.DirectorId).ToString())))
                                                  .ForMember(dst=> dst.PublisDate, opt=> opt.MapFrom(src=> (src.PublisDate.Date.ToString("dd-MM-yyyy"))))
                                                  .ForMember(dst=> dst.ActorName, opt=> opt.MapFrom(src=> src.Actor.Fullname));
                                                  
                                                  
            CreateMap<Movie,MoivesViewModel>()
                                                  .ForMember(dst=> dst.Genre, opt=> opt.MapFrom(src=> (((GenreEnum)src.GenreId).ToString())))
                                                  .ForMember(dst=> dst.ActorName, opt=> opt.MapFrom(src=> src.Actor.Fullname))
                                                  .ForMember(dst=> dst.Director, opt=> opt.MapFrom(src=> (((DirectorEnum)src.DirectorId).ToString())))
                                                  .ForMember(dst=> dst.PublisDate, opt=> opt.MapFrom(src=> (src.PublisDate.Date.ToString("dd-MM-yyyy"))));

            CreateMap<Actor,ActorsViewModel>()
                                                  .ForMember(dst=> dst.Birthday, opt=> opt.MapFrom(src=> src.Birthday.Date.ToString("dd-MM-yyyy")));
            CreateMap<Actor,ActorDetailViewModel>()
                                                  .ForMember(dst=> dst.Birthday, opt=> opt.MapFrom(src=> src.Birthday.Date.ToString("dd-MM-yyyy")));
            CreateMap<CreateActorModel,Actor>();
                                                  
                                                  
                                                  
        }
    }
}