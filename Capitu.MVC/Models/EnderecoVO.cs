using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capitu.MVC.Models
{
    public class EnderecoVO
    {
        public int Id { get; set; }

        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Display(Name = "Latitude:")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude:")]
        public string Longitude { get; set; }
    }
}