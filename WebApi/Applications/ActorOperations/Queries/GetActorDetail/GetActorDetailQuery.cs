using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common.Enums;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _dbContext;

        public GetActorDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
             var actor = _dbContext.Actors.Where(actor => actor.Id==ActorId).SingleOrDefault();

             if(actor is null)
               throw new InvalidOperationException("Oyuncu bulunamadı!");
            
            ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);
            return vm;
        }
    }
    public class ActorDetailViewModel
    {
        public string Fullname { get; set; }
        public string Birthday { get; set; }
    }
}