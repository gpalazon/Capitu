using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitu.BE;

namespace Capitu.DAL
{
    public class UsuarioDAL
    {

        public UsuarioBE Get(int idUsuario)
        {

            using (ACapituDBEntities db = new ACapituDBEntities())
            {
                Usuario user = db.Usuario.Find(idUsuario);
                
                UsuarioBE usuario = new UsuarioBE();

                usuario.Id = user.Id;
                usuario.Login = user.Login;
                usuario.Email = user.Email;
                usuario.Facebook = user.Facebook;
                usuario.FlAtivo = user.FlAtivo.GetValueOrDefault();

                return usuario;
            }
        }

        public int Incluir(UsuarioBE user) 
        {

            using (ACapituDBEntities db = new ACapituDBEntities()) 
            {
                Usuario usuario = new Usuario()
                {
                    Email = user.Email,
                    Facebook = user.Facebook,
                    Login = user.Login,
                    Nome = user.Nome,
                    FlAtivo = true
                };


                db.Usuario.Add(usuario);

                db.SaveChanges();

                return usuario.Id;
            }
        }

        public void Alterar(UsuarioBE user)
        {

            using (ACapituDBEntities db = new ACapituDBEntities())
            {
                Usuario usuario = db.Usuario.Find(user.Id);                

                usuario.Email = user.Email;
                usuario.Facebook = user.Facebook;
                usuario.Login = user.Login;
                usuario.Nome = user.Nome;
                usuario.FlAtivo = user.FlAtivo;                

                db.SaveChanges();
            }
        }

    }
}
