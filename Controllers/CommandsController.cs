using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;


namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repoository;
        public CommandsController(ICommanderRepo repository)
        {
            _repoository = repository;
        }
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands() => Ok(_repository.GetAllCommands()); 

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandBydId(int id) => Ok(_repository.GetCommandById(id));
    }
}