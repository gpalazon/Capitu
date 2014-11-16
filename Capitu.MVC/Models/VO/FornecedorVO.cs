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

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        [Display(Name = "Idade:")]
        public int Idade { get; set; }

        [Display(Name = "Altura:")]
        public int Altura { get; set; }

        [Display(Name = "Olhos:")]
        public string Olhos { get; set; }

        [Display(Name = "Etnia:")]
        public string Etnia { get; set; }

        [Display(Name = "Peso:")]
        public int Peso { get; set; }

        public ImagemVO ImgAvatar { get; set; }

        public ImagemVO ImgPerfil { get; set; }

        public List<ImagemVO> Fotos { get; set; }

        public string Descricao { get; set; }

        public DateTime DtNascimento { get; set; }

        public FornecedorBE ConvertToBE()
        {
            FornecedorBE ret = new FornecedorBE()
            {
                Usuario = new UsuarioBE() {
                    Email = Email,
                    Facebook = Facebook,
                    FlAtivo = FlAtivo,
                    Id = IdUsuario,
                    Login = Login                    
                },
                Altura = Altura,
                Descricao = Descricao,
                DtNascimento = DtNascimento,
                Etnia = Etnia,
                Fotos = new List<ImagemBE>(),
                Id = Id,
                Idade = Idade,
                Latitude = Latitude,
                Longitude = Longitude,
                Nome = Nome,
                Olhos = Olhos,
                Peso = Peso,
                Preco = Preco,
                //Avatar = ImgAvatar.ConvertToBE(),
                //ImgPerfil = ImgPerfil.ConvertToBE()
                ImgAvatarId = ImgAvatar.Id,
                ImgAvatarUrl = ImgAvatar.UrlImagem,
                ImgPerfilId = ImgPerfil.Id,
                ImgPerfilUrl = ImgPerfil.UrlImagem
            };

            foreach (var f in Fotos)
            {
                ret.Fotos.Add(f.ConvertToBE());
            }

            return ret;
        }

        public void GetFromBE(FornecedorBE fornecedor)
        {
            Altura = fornecedor.Altura;
            Descricao = fornecedor.Descricao;
            DtNascimento = fornecedor.DtNascimento;
            Etnia = fornecedor.Etnia;
            Fotos = new List<ImagemVO>();
            Id = fornecedor.Id;
            Idade = fornecedor.Idade;
            Latitude = fornecedor.Latitude;
            Longitude = fornecedor.Longitude;
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
        }


    }
}