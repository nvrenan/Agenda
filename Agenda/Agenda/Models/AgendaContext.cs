using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public sealed class AgendaContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        private static AgendaContext _context;

        public static AgendaContext GetInstance()
        {
            if (_context == null)
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AgendaContext>());
                _context = new AgendaContext();
            }
            return _context;
        }
    }
}