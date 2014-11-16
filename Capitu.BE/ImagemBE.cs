using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitu.BE
{
    public  class ImagemBE
    {
        public ImagemBE() { }

        public ImagemBE(int id, string url) 
        {
            Id = id;
            UrlImagem = url;
        }

        public int Id { get; set; }
        public string UrlImagem { get; set; }
    }
}
