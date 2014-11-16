using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitu.BE;
using Capitu.DAL;

namespace Capitu.BLL
{
    public class ContatoBLL
    {
        public void Salvar(string email) 
        {            
            ContatoDAL contatoDal = new ContatoDAL();
            
            Contato contato = new Contato();
            contato.Data = DateTime.Now;
            contato.Email = email;

            contatoDal.Salvar(contato);
        }

        public List<ContatoBE> GetContatos() 
        {
            ContatoDAL contatoDal = new ContatoDAL();
            return contatoDal.GetContatos();
        }
    }
}
