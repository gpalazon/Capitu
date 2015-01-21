using Capitu.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitu.DAL
{
    public class EtniaDAL
    {
        public List<EtniaBE> GetEtnias(){

            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {

                var q = from e in db.Etnia
                        select new EtniaBE() {
                            Id = e.Id,
                            DsEtnia = e.DsEtnia

                        };

                return (List<EtniaBE>)q.ToList();
            }

        }
    }
}
