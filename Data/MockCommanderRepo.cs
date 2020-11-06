using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut Bread", Line="Get a knife", Platform="Knife & chopping board"},
                new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & Cup"}
            };
        }

        public IEnumerable<Command> GetByHowToLike(string name)
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int Id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}