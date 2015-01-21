using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitu.BE;

namespace Capitu.DAL
{
    public class ContatoDAL
    {
        public void Salvar(Contato contato)
        {
            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                db.Contato.Add(contato);
                db.SaveChanges();
            }
        }

        public List<ContatoBE> GetContatos()
        {
            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                var q = from c in db.Contato
                        select new ContatoBE()
                        {
                            Email = c.Email
                        };

                //return (List<ContatoBE>)q.ToList();
                return (List<ContatoBE>)q.Distinct().OrderBy(x => x.Email).ToList();
            }
        }
    }
}
