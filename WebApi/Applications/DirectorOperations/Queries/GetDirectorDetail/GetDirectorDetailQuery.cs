using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public DirectorViewModel Handle()
        {
            var director= _dbContext.Directors.Include(x=> x.DirectorMovies).SingleOrDefault(x=> x.Id==DirectorId);

            if(director is null)
               throw new InvalidOperationException($"{DirectorId} id'li yönetmen mevcut değil!");
            DirectorViewModel vm=_mapper.Map<DirectorViewModel>(director);
            return vm;
        }
    }
    public class DirectorViewModel
    {
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public List<string> DirectorMovies { get; set; }
    }
}