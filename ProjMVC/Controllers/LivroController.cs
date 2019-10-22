using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro

        public ActionResult Index()
        {
            bdlivroEntities1 context = new bdlivroEntities1();
            var lst = context.tb_livro.ToList();
            return View(lst);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Cadastrar(tb_livro livro)
        {
            if (ModelState.IsValid)
            {
                bdlivroEntities1 context = new bdlivroEntities1();
                context.tb_livro.Add(livro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Editar(int id)
        {
            bdlivroEntities1 context = new bdlivroEntities1();
            return View(context.tb_livro.First(l => l.id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Editar(tb_livro livro)
        {
            if (ModelState.IsValid)
            {
                bdlivroEntities1 context = new bdlivroEntities1();
                tb_livro li = context.tb_livro.First(l => l.id == livro.id);
                li.nome = livro.nome;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Detalhe(int id)
        {
            return View(new bdlivroEntities1().tb_livro.First(l => l.id == id));
        }

        public ActionResult Excluir(int id)
        {
            return View(new bdlivroEntities1().tb_livro.First(l => l.id == id));
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        
        public ActionResult ConfirmaExcluir(int id)
        {
            bdlivroEntities1 context = new bdlivroEntities1();
            tb_livro livro = context.tb_livro.First(l => l.id == id);
            context.tb_livro.Remove(livro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}