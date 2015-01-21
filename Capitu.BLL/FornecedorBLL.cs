using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitu.BE;
using Capitu.DAL;

namespace Capitu.BLL
{
    public class FornecedorBLL
    {
        private FornecedorDAL _fornDal;

        public List<FornecedorBE> GetFornecedores(int idEtnia, string nome) 
        {
            try 
            {
                _fornDal = new FornecedorDAL();
                return _fornDal.GetFornecedores(idEtnia, nome);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public FornecedorBE GetFornecedor(int idFornecedor)
        {
            _fornDal = new FornecedorDAL();
            return _fornDal.GetFornecedor(idFornecedor);
        }

        public void Save(FornecedorBE fornecedor) 
        {
            _fornDal = new FornecedorDAL();

            if (fornecedor.Id > 0)
            {
                _fornDal.Alterar(fornecedor);
            }
            else 
            {
                _fornDal.Incluir(fornecedor);
            }
        }

        public void Delete(int idFornecedor)
        {
            _fornDal = new FornecedorDAL();
            _fornDal.Delete(idFornecedor);
            
        }
    }
}
