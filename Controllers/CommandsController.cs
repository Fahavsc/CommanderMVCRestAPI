using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands() =>
         Ok(_mapper.Map<IEnumerable<CommandReadDto>>(_repository.GetAllCommands())); 

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));

            return NotFound();
        }

        [HttpGet("like")]
        public ActionResult<IEnumerable<CommandReadDto>> GetHowToLike([FromBody] string name)
        {
            var commandItem = _repository.GetByHowToLike(name);
            if(commandItem != null)
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdDto){
            var commandModel = _mapper.Map<Command>(cmdDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var cmdReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = cmdReadDto.Id}, cmdReadDto);
            //return Ok();
        }

        //PUT api/commands/{id}
        [HttpPut("{id}", Name = "")]   
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();
                
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);
            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommands(int id){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}