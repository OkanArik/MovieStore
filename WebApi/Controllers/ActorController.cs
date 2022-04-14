using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.Applications.ActorOperations.Commands.DeleteActor;
using WebApi.Applications.ActorOperations.Commands.UpdateActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.MovieOperations.Queries.GetActors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route ("[Controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        [HttpGet]
           public IActionResult GetActors ()
           {
               GetActorsQuery query = new GetActorsQuery(_dbContext,_mapper);
               var result= query.Handle();
               return Ok(result);
           }

           [HttpGet ("{id}")]
           public IActionResult GetById ( int id)
           {
               GetActorDetailQuery query = new GetActorDetailQuery(_dbContext,_mapper);

                   query.ActorId=id;
                   GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
                   validator.ValidateAndThrow(query);
                   var result=query.Handle();
                   return Ok(result);

           }
        
            [HttpPost]
            public IActionResult CreateActor([FromBody] CreateActorModel createdActor)
            {
                CreateActorCommand command = new CreateActorCommand(_dbContext,_mapper);

                    command.Model=createdActor;
                    CreateActorCommandValidator validator = new CreateActorCommandValidator();
                    ValidationResult result=validator.Validate(command);
                    validator.ValidateAndThrow(command);
                    command.Handle();

                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateActor([FromBody]UpdateActorModel updatedMoive , int id)
            {
                UpdateActorCommand command= new UpdateActorCommand(_dbContext);   

                    command.ActorId=id;
                    command.Model=updatedMoive;
                    UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
                    validator.ValidateAndThrow(command);
                    command.Handle();
                

                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteActor(int id)
            {
                DeleteActorCommand command = new DeleteActorCommand(_dbContext);

                    command.ActorId=id;
                    DeleteActorCommandValidator validator=new DeleteActorCommandValidator();
                    validator.ValidateAndThrow(command);
                    command.Handle();
    
                return Ok();
            }
        
    }
}