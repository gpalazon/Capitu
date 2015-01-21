using Capitu.BE;
using Capitu.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Capitu.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<FornecedorDTO> GetPin() 
        {
            List<FornecedorDTO> ret = new List<FornecedorDTO>();
            FornecedorBLL fornBll = new FornecedorBLL();
            foreach (FornecedorBE f in fornBll.GetFornecedores(0, string.Empty)) 
            {
                ret.Add(new FornecedorDTO()
                {
                    Altura = f.Altura,
                    Endereco = f.Endereco,
                    Etnia = f.Etnia.DsEtnia,
                    GeoLat = (Double)f.Latitude,
                    GeoLong = (Double)f.Longitude,
                    Id = f.Id,
                    Idade = f.Idade,
                    Imagem = f.ImgPerfilUrl,
                    Nome = f.Nome,
                    Olhos = f.Olhos,
                    Preco = f.Preco,
                    Descricao = f.Descricao
                });
            }

            return ret;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
