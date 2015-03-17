using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capitu.MVC.Models
{
    public class ContatoVO
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "E-mail", Prompt = "Insira seu e-mail aqui")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [PlaceHolder("Digite seu e-mail")]
        public string Email { get; set; }
    }
}