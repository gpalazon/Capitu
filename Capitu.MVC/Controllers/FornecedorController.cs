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
using System.Net;
using System.IO;
using System.Text;

namespace Capitu.MVC.Controllers
{
    [Authorize]
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


        public void ConfigurarViewBag(int idEtnia = 0)
        {
            EtniaBLL etBll = new EtniaBLL();

            List<SelectListItem> etList = new List<SelectListItem>();

            //etList.Add(new SelectListItem { Text = "BUSCAR POR...", Value = "0" });

            foreach (EtniaBE item in etBll.GetEtnias())
            {
                if (idEtnia > 0)
                {
                    etList.Add(new SelectListItem { Text = item.DsEtnia, Value = item.Id.ToString(), Selected = item.Id == idEtnia });
                }
                else {
                    etList.Add(new SelectListItem { Text = item.DsEtnia, Value = item.Id.ToString() });
                }
                
            }


            //ViewBag.EtniaList = etList;
            ViewBag.EtniaList = new SelectList(etList, "Value", "Text");

            ViewBag.Message = "...";

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

        [AllowAnonymous]
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
            ConfigurarViewBag();
            return View();
        }

        //
        // POST: /Fornecedor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorVO fornecedor)
        {
            //if (ModelState.IsValid)
            //{
                _fornecedorBll = new FornecedorBLL();

                FornecedorBE fornBe = new FornecedorBE();

                fornBe = fornecedor.ConvertToBE();                

                _fornecedorBll.Save(fornBe);

                return RedirectToAction("Index");
            //}

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

            ConfigurarViewBag(fornecedor.Etnia.Id);            

            return View("Create", fornecedor);
            //return View(fornecedor);

        }

        //
        // POST: /Fornecedor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorVO fornecedor)
        {
            //if (ModelState.IsValid)            
            //{
                _fornecedorBll = new FornecedorBLL();                
                FornecedorBE fornBe = new FornecedorBE();
                
                fornBe = fornecedor.ConvertToBE();

                _fornecedorBll.Save(fornBe);

                return RedirectToAction("Index");
            //}
            //return View(fornecedor);
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


        public PartialViewResult Listar(FornecedorVO model)
        {
            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + model.Endereco + "&sensor=false";
            WebRequest request = WebRequest.Create(url);

            List<EnderecoVO> list = new List<EnderecoVO>();

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    DataTable dtCoordinates = new DataTable();
                    dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
                        new DataColumn("Address", typeof(string)),
                        new DataColumn("Latitude",typeof(string)),
                        new DataColumn("Longitude",typeof(string)) });
                    foreach (DataRow row in dsResult.Tables["result"].Rows)
                    {
                        string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                        DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                        dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);

                        list.Add(new EnderecoVO()
                        {
                            Id = int.Parse(row["result_id"].ToString()),
                            Endereco = row["formatted_address"].ToString(),
                            Latitude = location["lat"].ToString(),
                            Longitude = location["lng"].ToString()
                        });
                    }

                    //GridView1.DataSource = dtCoordinates;
                    //GridView1.DataBind();
                }
            }

            //ViewBag["ListaEnderecos"] = list;

            return PartialView("_ListaEnderecos", list);
        }
    }
}