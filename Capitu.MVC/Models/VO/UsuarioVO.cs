using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitu.BE;

namespace Capitu.MVC.Models
{
    public class UsuarioVO
    {
        public int IdUsuario { get; set; }

        //public string Nome { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public bool FlAtivo { get; set; }

        /*public UsuarioBE ConvertToBE()
        {
            UsuarioBE ret = new UsuarioBE()
            {
                Email = Email,
                Facebook = Facebook,
                FlAtivo = FlAtivo,
                Id = IdUsuario,
                Login = Login,                
            };

            return ret;
        }

        public void GetFromBE(UsuarioBE user)
        {
            Email = user.Email;
            Facebook = user.Facebook;
            FlAtivo = user.FlAtivo;
            IdUsuario = user.Id;
            Login = user.Login;            
        }*/

    }
}