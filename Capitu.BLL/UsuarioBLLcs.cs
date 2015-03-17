using Capitu.BE;
using Capitu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitu.BLL
{
    public class UsuarioBLL
    {
        public UsuarioBE ValidarUsuario(string login, string senha) {

            UsuarioDAL userDal = new UsuarioDAL();
            return userDal.Validar(login, senha);            
        }
    }
}
