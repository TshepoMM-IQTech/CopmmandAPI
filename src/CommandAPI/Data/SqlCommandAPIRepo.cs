using System;
using System.Collections.Generic;
using System.Linq;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        void ICommandAPIRepo.CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Remove(cmd);
        }

        IEnumerable<Command> ICommandAPIRepo.GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        Command ICommandAPIRepo.GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);            
        }

        bool ICommandAPIRepo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        void ICommandAPIRepo.UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}