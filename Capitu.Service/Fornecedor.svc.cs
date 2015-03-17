using Capitu.BE;
using Capitu.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Capitu.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Fornecedor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Fornecedor.svc or Fornecedor.svc.cs at the Solution Explorer and start debugging.
    public class Fornecedor : IFornecedor
    {
        public void DoWork()
        {
        }

        public List<FornecedorDTO> GetFornecedores()
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
    }
}
