using Capitu.BE;
using Capitu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitu.BLL
{
    public class EtniaBLL
    {       
        public List<EtniaBE> GetEtnias() 
        {            
            EtniaDAL etDal = new EtniaDAL();

            return etDal.GetEtnias();
        }
    }
}
