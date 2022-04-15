using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;
using WebApi.Applications.DirectorOperations.Commands.DeleteDirector;
using WebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Applications.DirectorOperations.Queries.GetDirectors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]//Controller'ın http response döneceğini taahhüt ettiğimiz attribute
    [Route("[Controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DirectorController(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query=new GetDirectorsQuery(_dbContext,_mapper);
                var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetDirectorDetailQuery query= new GetDirectorDetailQuery(_dbContext,_mapper);
                query.DirectorId=id;

            GetDirectorDetailQueryValidator validator=new GetDirectorDetailQueryValidator();
                validator.ValidateAndThrow(query);

                var result = query.Handle();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_dbContext,_mapper);
                command.Model=newDirector;

            CreateDirectorCommandValidator validator=new CreateDirectorCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id,[FromBody] UpdateDirectorModel updatedDirector)
        {
            UpdateDirectorCommand command=new UpdateDirectorCommand(_dbContext);
                command.DirectorId=id;
                command.Model=updatedDirector;

            UpdateDirectorCommandValidator validator =new UpdateDirectorCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_dbContext);
                command.DirectorId=id;

            DeleteDirectorCommandValidator validator=new DeleteDirectorCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();

            return Ok(); 
        }
        
    }
}