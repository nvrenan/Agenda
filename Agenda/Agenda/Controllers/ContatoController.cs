using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/
        private ContatoRepository _contatoRepository = new ContatoRepository();

        public ActionResult Index()
        {
            return View(_contatoRepository.BuscaTodos());
        }

        //
        // GET: /Contato/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Contato/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contato/Create

        [HttpPost]
        public ActionResult Create(Contato contato)
        {
            try
            {
                // TODO: Add insert logic here
                _contatoRepository.Adiciona(contato);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contato/Edit/5

        public ActionResult Edit(int id)
        {
            Contato contato = _contatoRepository.BuscaPorId(id);
            return View(contato);
        }

        //
        // POST: /Contato/Edit/5

        [HttpPost]
        public ActionResult Edit(Contato contato)
        {
            try
            {
                var contatoAnterior = _contatoRepository.BuscaPorId(contato.Id);
                _contatoRepository.Editar(contatoAnterior, contato);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contato/Delete/5

        public ActionResult Delete(int id)
        {
            Contato contato = _contatoRepository.BuscaPorId(id);
            return View(contato);
        }

        //
        // POST: /Contato/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Contato contato = _contatoRepository.BuscaPorId(id);
                _contatoRepository.Excluir(contato);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
