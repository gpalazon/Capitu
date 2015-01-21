using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capitu.MVC.Models
{
    public class EtniaVO
    {
        public int Id { get; set; }

        [Display(Name = "Etnia:")]
        public string DsEtnia { get; set; }
    }
}