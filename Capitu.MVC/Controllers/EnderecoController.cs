using Capitu.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Capitu.MVC.Controllers
{
    public class EnderecoController : Controller
    {
        //
        // GET: /Endereco/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar2() 
        {
            string endereco = "Rua das Caneleiras, São Paulo";

            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + endereco + "&sensor=false";
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

            //ViewBag.["ListaEnderecos"] = list;

            return PartialView("_ListaEnderecos", list);
        }
        
        public ActionResult Listar(string endereco) 
        {
            if (!string.IsNullOrEmpty(endereco))
            {

                string url = "http://maps.google.com/maps/api/geocode/xml?address=" + endereco + "&sensor=false";
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

                //ViewBag.["ListaEnderecos"] = list;

                return PartialView("_ListaEnderecos", list);
            }            
            else{
                return PartialView("_ListaEnderecos");
            }
        }

        public ActionResult Select(int id = 0) {

            List<EnderecoVO> list = (List<EnderecoVO>)ViewBag["ListaEnderecos"];
            EnderecoVO end = list.Find(x => x.Id == id);

            return View();
        }



    }
}
