using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitu.BE;

namespace Capitu.MVC.Models
{
    public class ImagemVO
    {
        public int Id { get; set; }

        public string UrlImagem { get; set; }

        public ImagemBE ConvertToBE()
        {
            return new ImagemBE(Id, UrlImagem);
        }
        
        public void GetFromBE(ImagemBE img)
        {
            Id = img.Id;
            UrlImagem = img.UrlImagem;
        }

    }
    
}