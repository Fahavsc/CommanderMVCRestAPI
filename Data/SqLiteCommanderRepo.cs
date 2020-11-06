using System.Collections.Generic;
using System.Linq;
using System;
using Commander.Models;

namespace Commander.Data
{
    public class SqLiteCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SqLiteCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {

            return _context.Commands.ToList();
        }

        public IEnumerable<Command> GetByHowToLike(string name)
        {
            return _context.Commands.ToList().Where( cmd => cmd.HowTo.Contains(name));
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(cmd => cmd.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            _context.Commands.Update(cmd);
        }
    }
}