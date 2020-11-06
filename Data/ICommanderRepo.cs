using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        IEnumerable<Command> GetByHowToLike(string name);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
    }
}