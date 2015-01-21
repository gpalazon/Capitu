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

            using (CAPITUDBEntities db = new CAPITUDBEntities())
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

        public UsuarioBE Validar(string login, string senha)
        {

            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                var q = from u in db.Usuario
                        where u.Login == login
                        && u.Senha == senha
                        select new UsuarioBE()
                        {
                            Id = u.Id,
                            Login = u.Login,
                            Email = u.Email,
                            Facebook = u.Facebook,
                            FlAtivo = u.FlAtivo.Value
                        };

                return (UsuarioBE)q.FirstOrDefault();                
            }
        }

        public int Incluir(UsuarioBE user) 
        {

            using (CAPITUDBEntities db = new CAPITUDBEntities()) 
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

            using (CAPITUDBEntities db = new CAPITUDBEntities())
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
