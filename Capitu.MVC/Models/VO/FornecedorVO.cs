using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capitu.BE;

namespace Capitu.MVC.Models
{
    public class FornecedorVO : UsuarioVO
    {
        
        public int Id { get; set; }

        [Display(Name="Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Preço:")]
        public decimal Preco { get; set; }


        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        [Display(Name = "Idade:")]
        public int Idade { get; set; }

        [Display(Name = "Altura:")]
        public decimal Altura { get; set; }

        [Display(Name = "Olhos:")]
        public string Olhos { get; set; }

        //[Display(Name = "Etnia:")]
        //
        //public string Etnia { get; set; }
        public EtniaVO Etnia { get; set; }

        [Display(Name = "Peso:")]
        public int Peso { get; set; }

        public ImagemVO ImgAvatar { get; set; }

        public ImagemVO ImgPerfil { get; set; }

        public List<ImagemVO> Fotos { get; set; }

        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }

        public string Descricao { get; set; }

        public DateTime DtNascimento { get; set; }

        public FornecedorBE ConvertToBE()
        {
            FornecedorBE ret = new FornecedorBE();
            
            ret.Usuario = new UsuarioBE();
                
            ret.Usuario.Email = Email;
            ret.Usuario.Facebook = Facebook;
            ret.Usuario.FlAtivo = true;//FlAtivo,
            ret.Usuario.Id = IdUsuario;
            ret.Usuario.Login = Email;//Login                

            ret.Altura = Altura;

            ret.Descricao = Descricao;
            ret.DtNascimento = DtNascimento;
            ret.Etnia = new EtniaBE() 
            {
                Id = Etnia.Id,
                DsEtnia = Etnia.DsEtnia
            };
            ret.Fotos = new List<ImagemBE>();
            ret.Id = Id;
            ret.Idade = Idade;
            ret.Latitude = decimal.Parse(Latitude.Replace(".",","));
            ret.Longitude = decimal.Parse(Longitude.Replace(".", ","));
            ret.Nome = Nome;
            ret.Olhos = Olhos;
            ret.Peso = Peso;
            ret.Preco = Preco;
            ret.Telefone = Telefone;
            ret.Endereco = Endereco;

            //Avatar = ImgAvatar.ConvertToBE(),
            //ImgPerfil = ImgPerfil.ConvertToBE()
            
            if (ImgAvatar != null) 
            {
                ret.ImgAvatarId = ImgAvatar.Id;
                ret.ImgAvatarUrl = ImgAvatar.UrlImagem;                
            }

            if (ImgPerfil != null)
            {
                ret.ImgPerfilId = ImgPerfil.Id;
                ret.ImgPerfilUrl = ImgPerfil.UrlImagem;                
            }

            if (Fotos != null) 
            {                
                foreach (var f in Fotos)
                {
                    ret.Fotos.Add(f.ConvertToBE());
                }
            }
            return ret;
        }

        public void GetFromBE(FornecedorBE fornecedor)
        {
            Altura = fornecedor.Altura;
            Descricao = fornecedor.Descricao;
            DtNascimento = fornecedor.DtNascimento;
            Etnia = new EtniaVO()
            {
                Id = fornecedor.Etnia.Id,
                DsEtnia = fornecedor.Etnia.DsEtnia
            };
            Fotos = new List<ImagemVO>();
            Id = fornecedor.Id;
            Idade = fornecedor.Idade;
            Latitude = fornecedor.Latitude.ToString().Replace(",",".");
            Longitude = fornecedor.Longitude.ToString().Replace(",", ".");
            Nome = fornecedor.Nome;
            Olhos = fornecedor.Olhos;
            Peso = fornecedor.Peso;
            Preco = fornecedor.Preco;
            ImgAvatar = new ImagemVO();
            ImgPerfil = new ImagemVO();

            //ImgAvatar.GetFromBE(fornecedor.Avatar);
            //ImgPerfil.GetFromBE(fornecedor.ImgPerfil);
            ImgAvatar.Id = fornecedor.ImgAvatarId.GetValueOrDefault();
            ImgAvatar.UrlImagem = fornecedor.ImgAvatarUrl;

            ImgPerfil.Id = fornecedor.ImgPerfilId.GetValueOrDefault();
            ImgPerfil.UrlImagem = fornecedor.ImgPerfilUrl;

            if (fornecedor.Fotos != null)
            {
                foreach (var f in fornecedor.Fotos)
                {
                    ImagemVO img = new ImagemVO();
                    img.GetFromBE(f);

                    Fotos.Add(img);
                }
            }

            Email = fornecedor.Usuario.Email;
            Facebook = fornecedor.Usuario.Facebook;
            FlAtivo = fornecedor.Usuario.FlAtivo;
            IdUsuario = fornecedor.Usuario.Id;
            Login = fornecedor.Usuario.Login;
            Telefone = fornecedor.Telefone;
            Endereco = fornecedor.Endereco;
        }


    }
}