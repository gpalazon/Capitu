using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitu.MVC.Models
{
    public class PinVO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        public string Olhos { get; set; }

        public string Etnia { get; set; }

        public int Idade { get; set; }

        public double GeoLong { get; set; }

        public double GeoLat { get; set; }

        public double Preco { get; set; }
    }
}