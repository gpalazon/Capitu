using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitu.BE
{
    public class FornecedorBE
    {
        

        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public decimal Preco { get; set; }

        public decimal Longitude { get; set; }
        
        public decimal Latitude { get; set; }       
        
        public int Idade { get; set; }
        
        public int Altura { get; set; }
        
        public string Olhos { get; set; }
        
        public string Etnia { get; set; }
        
        public int Peso { get; set; }

        //public ImagemBE Avatar { get; set; }
        
        public int? ImgAvatarId { get; set; }
        
        public string ImgAvatarUrl { get; set; }

        //public ImagemBE ImgPerfil { get; set; }
        
        public int? ImgPerfilId { get; set; }

        public string ImgPerfilUrl { get; set; }


        public List<ImagemBE> Fotos { get; set; }

        public string Descricao { get; set; }

        public DateTime DtNascimento { get; set; }

        public UsuarioBE Usuario { get; set; }
    }
}
