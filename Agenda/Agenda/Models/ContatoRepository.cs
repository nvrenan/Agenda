using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public class ContatoRepository
    {
        private static AgendaContext _context;

        public ContatoRepository()
        {
            _context = AgendaContext.GetInstance();
        }

        public IList<Contato> BuscaTodos()
        {
            var consulta = from e in _context.Contatos select e;
            return consulta.ToList();
        }

        public Contato BuscaPorId(int id)
        {
            Contato contato = _context.Contatos.Find(id);
            return contato;
        }

        public void Adiciona(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public void Editar(Contato contatoAntigo, Contato contatoNovo)
        {
            _context.Entry(contatoAntigo).CurrentValues.SetValues(contatoNovo);
            _context.SaveChanges();
        }

        public void Excluir(Contato contato)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }
}