using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Applications.MovieOperations.Commands.DeleteMovie;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using WebApi.Applications.MovieOperations.Queries.GetMovies;

namespace WebApi.Controllers
{
    [ApiController] 
    [Route("[Controller]s")]
    public class MovieController : ControllerBase 
    {
           private readonly  MovieStoreDbContext _dbContext;
           private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
           public IActionResult GetMovies ()
           {
               GetMoviesQuery query = new GetMoviesQuery(_dbContext,_mapper);
               var result= query.Handle();
               return Ok(result);
           }

           [HttpGet ("{id}")]
           public IActionResult GetById ( int id)
           {
               GetMovieDetailQuery query = new GetMovieDetailQuery(_dbContext,_mapper);

                   query.MovieId=id;
                   GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
                   validator.ValidateAndThrow(query);
                   var result=query.Handle();
                   return Ok(result);

           }
        
            [HttpPost]
            public IActionResult CreateMovie([FromBody] CreateMovieModel createdMovie)
            {
                CreateMovieCommand command = new CreateMovieCommand(_dbContext,_mapper);

                    command.Model=createdMovie;
                    CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                    ValidationResult result=validator.Validate(command);
                    validator.ValidateAndThrow(command);
                    command.Handle();

                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateMovie([FromBody]UpdateMovieModel updatedMoive , int id)
            {
                UpdateMovieCommand command= new UpdateMovieCommand(_dbContext);   

                    command.MovieId=id;
                    command.Model=updatedMoive;
                    UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
                    validator.ValidateAndThrow(command);
                    command.Handle();
                

                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMovie(int id)
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_dbContext);

                    command.MovieId=id;
                    DeleteMovieCommandValidator validator=new DeleteMovieCommandValidator();
                    validator.ValidateAndThrow(command);
                    command.Handle();
    
                return Ok();
            }

    }
}