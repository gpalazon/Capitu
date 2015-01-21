using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capitu.BE;
using Capitu.BLL;
using Capitu.MVC.Models;

namespace Capitu.MVC.Controllers
{
    public class MapaController : Controller
    {
        //
        // GET: /Mapa/

        public ActionResult Index()
        {
            ConfigurarViewBag();
            return View("View1");
            //return View(); 
        }

        public void ConfigurarViewBag()
        {
            EtniaBLL etBll = new EtniaBLL();
            
            List<SelectListItem> etList = new List<SelectListItem>();

            etList.Add(new SelectListItem { Text = "BUSCAR POR...", Value = "0" }); 

            foreach (EtniaBE item in etBll.GetEtnias())
            {
                etList.Add(new SelectListItem { Text = "BUSCAR POR " + item.DsEtnia + "S", Value = item.Id.ToString() }); 
            }

            etList[etList.Count - 1].Selected = true;

            //ViewBag.EtniaList = etList;
            ViewBag.EtniaList = new SelectList(etList, "Value", "Text");
            
            ViewBag.Message = "...";

        }

        /*public ActionResult Index()
        {
            List<PinVO> pinList = new List<PinVO>();

            FornecedorBLL fornecedorBll = new FornecedorBLL();            

            foreach (FornecedorBE f in fornecedorBll.GetFornecedores(0, string.Empty))
            {
                FornecedorVO fornVo = new FornecedorVO();

                pinList.Add(new PinVO()
                {
                    Etnia = f.Etnia,
                    GeoLat = (Double)f.Latitude,
                    GeoLong = (Double)f.Longitude,
                    Id = f.Id,
                    Idade = f.Idade,
                    Imagem = f.ImgPerfilUrl,
                    Nome = f.Nome,
                    Olhos = f.Olhos,
                    Preco = (Double)f.Preco
                });                
            }

            return View(pinList);
        }*/


        public ActionResult GetPin(string etnia)
        {

            List<PinVO> pinList = new List<PinVO>();

            FornecedorBLL fornecedorBll = new FornecedorBLL();

            foreach (FornecedorBE f in fornecedorBll.GetFornecedores(string.IsNullOrEmpty(etnia) ? 0 : int.Parse(etnia), string.Empty))
            {
                FornecedorVO fornVo = new FornecedorVO();

                pinList.Add(new PinVO()
                {
                    Etnia = f.Etnia.DsEtnia,
                    GeoLat = (Double)f.Latitude,
                    GeoLong = (Double)f.Longitude,
                    Id = f.Id,
                    Idade = f.Idade,
                    Imagem = f.ImgPerfilUrl.Replace("/Images", "Images"),
                    Nome = f.Nome,
                    Olhos = f.Olhos,
                    Preco = (Double)f.Preco
                });                
            }


            /*pinList.Add(new PinVO()
            {
                Etnia =  "Morena",
                GeoLat = -46.6557745,
                GeoLong =  -23.561965,
                Id =  1,
                Idade  = 19,
                Imagem = "Images/modelo1.jpg",
                Nome  = "Ana Bella",
                Olhos = "Verdes",
                Preco =  250
            });

            pinList.Add(new PinVO()
            {
                Etnia = "Morena",
                GeoLat = -46.6552704,
                GeoLong = -23.5681011,
                Id = 5,
                Idade = 25,
                Imagem = "Images/modelo2.png",
                Nome = "Barbara",
                Olhos = "Verdes",
                Preco = 275
            });

            pinList.Add(new PinVO()
            {
                Etnia = "Loira",
                GeoLat = -46.6552704,
                GeoLong = -23.566491,
                Id = 6,
                Idade = 25,
                Imagem = "Images/modelo4.jpg",
                Nome = "Julia",
                Olhos = "Verdes",
                Preco = 200
            });

            pinList.Add(new PinVO()
            {
                Etnia = "Loira",
                GeoLat = -46.6509546,
                GeoLong = -23.567757,
                Id = 7,
                Idade = 27,
                Imagem = "Images/modelo12.jpg",
                Nome = "Jessica",
                Olhos = "Pretos",
                Preco = 250
            });
             */

            /*{ "Id": 1, "GeoLong": "", "GeoLat": "-46.6557745", "Nome": "Ana Bella", "Imagem": "Images/modelo1.jpg", "Idade": "18", "Olhos": "Verdes", "Etnia": "Morena", "Preco": "R$200" },
                { "Id": 2, "GeoLong": "-23.5681011", "GeoLat": "-46.6552704", "Nome": "Barbara", "Imagem": "Images/modelo2.png", "Idade": "25", "Olhos": "Verdes", "Etnia": "Morena", "Preco": "R$250" },
                { "Id": 3, "GeoLong": "-23.566491", "GeoLat": "-46.6482424", "Nome": "Julia", "Imagem": "Images/modelo4.jpg", "Idade": "19", "Olhos": "Verdes", "Etnia": "Loira", "Preco": "R$275" },
                { "Id": 4, "GeoLong": "-23.567757", "GeoLat": "-46.6509546", "Nome": "Jessica", "Imagem": "Images/modelo12.jpg", "Idade": "23", "Olhos": "Pretos", "Etnia": "Negra", "Preco": "R$250" }                
             */
            //return View();
            return Json(pinList, JsonRequestBehavior.AllowGet);
        }

    }
}
