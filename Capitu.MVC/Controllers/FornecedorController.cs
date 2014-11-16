using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capitu.BE;
using Capitu.BLL;
using Capitu.MVC.Models;

namespace Capitu.MVC.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorBLL _fornecedorBll;

        //private CapituDBEntities db = new CapituDBEntities();

        //
        // GET: /Fornecedor/

        private int Idade(DateTime dtNascimento)
        {
            DateTime hoje = DateTime.Now;
            return (int)(hoje.Subtract(dtNascimento).Days * 365);
        }


        /*public ActionResult View1() 
        {
            return View();
        }*/

        public ActionResult Index()
        {
            _fornecedorBll = new FornecedorBLL();
            
            List<FornecedorVO> ret = new List<FornecedorVO>();

            foreach (FornecedorBE fornBe in _fornecedorBll.GetFornecedores(0, string.Empty)) 
            {
                FornecedorVO fornVo = new FornecedorVO();
                
                fornVo.GetFromBE(fornBe);                

                ret.Add(fornVo);    
            }

            return View(ret);
        }

        //
        // GET: /Fornecedor/Details/5

        public ActionResult Details(int id = 0)
        {
            _fornecedorBll = new FornecedorBLL();

            FornecedorVO ret = new FornecedorVO();

            ret.GetFromBE(_fornecedorBll.GetFornecedor(id));            

            return View(ret);            
        }

        public ActionResult View1(int id = 0)
        {
            _fornecedorBll = new FornecedorBLL();

            FornecedorVO ret = new FornecedorVO();

            ret.GetFromBE(_fornecedorBll.GetFornecedor(id));

            return View(ret);
        }

        public ActionResult Perfil(int id = 0)
        {
            _fornecedorBll = new FornecedorBLL();

            FornecedorVO ret = new FornecedorVO();

            ret.GetFromBE(_fornecedorBll.GetFornecedor(id));

            return View(ret);
        }

        //
        // GET: /Fornecedor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fornecedor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorVO fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorBll = new FornecedorBLL();

                FornecedorBE fornBe = new FornecedorBE();

                fornBe = fornecedor.ConvertToBE();                

                _fornecedorBll.Save(fornBe);

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        //
        // GET: /Fornecedor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            _fornecedorBll = new FornecedorBLL();

            FornecedorVO fornecedor = new FornecedorVO();
            fornecedor.GetFromBE(_fornecedorBll.GetFornecedor(id));

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        //
        // POST: /Fornecedor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorVO fornecedor)
        {
            if (ModelState.IsValid)            
            {
                _fornecedorBll = new FornecedorBLL();                
                FornecedorBE fornBe = new FornecedorBE();
                
                fornBe = fornecedor.ConvertToBE();

                _fornecedorBll.Save(fornBe);

                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        //
        // GET: /Fornecedor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            _fornecedorBll = new FornecedorBLL();
            FornecedorVO fornecedor = new FornecedorVO();
            fornecedor.GetFromBE(_fornecedorBll.GetFornecedor(id));            
            
            return View(fornecedor);
        }

        //
        // POST: /Fornecedor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _fornecedorBll = new FornecedorBLL();
            _fornecedorBll.Delete(id);            

            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/
        
    }
}