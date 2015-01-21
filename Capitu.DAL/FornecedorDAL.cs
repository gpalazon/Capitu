using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitu.BE;

namespace Capitu.DAL
{
    public class FornecedorDAL
    {

        private int Idade(DateTime dtNascimento)
        {
            DateTime hoje = DateTime.Now;
            return (int)(hoje.Subtract(dtNascimento).Days * 365);
        }

        public List<FornecedorBE> GetFornecedores(int idEtnia, string nome)
        {

            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                var q = from f in db.Fornecedor
                        from ip in db.Imagem.Where(x => x.Id == f.ImagemPerfilId).DefaultIfEmpty()
                        join e in db.Etnia on f.EtniaId equals e.Id
                        //from ia in db.Avatar.Where(x => x.Id == f.ImagemAvatarId).DefaultIfEmpty()
                        join u in db.Usuario on f.UsuarioId equals u.Id
                        where idEtnia <= 0 || e.Id == idEtnia
                        select new FornecedorBE()
                        {
                            Id = f.Id,
                            Etnia = new EtniaBE()                                                         
                            {
                                Id = e.Id,
                                DsEtnia = e.DsEtnia
                            },
                            //Idade = Idade(f.DtNascimento.Value),
                            Idade = 23,
                            Usuario = new UsuarioBE()
                            {
                                Id = u.Id,
                                Nome = u.Nome,
                                Email = u.Email,
                                Facebook = u.Facebook,
                                FlAtivo = u.FlAtivo.Value,
                                Login = u.Login
                            },
                            DtNascimento = f.DtNascimento.Value,
                            /*ImgPerfil = new ImagemBE(){                            
                                Id = ip.Id, 
                                UrlImagem = ip.UrlImagem
                            },*/
                            ImgPerfilId = ip.Id,
                            ImgPerfilUrl = ip.UrlImagem,
                            Latitude = f.Latitude,
                            Longitude = f.Longitude,
                            Nome = f.Nome,
                            Olhos = f.Olhos,
                            Preco = f.Preco,
                            Peso = f.Peso.Value,
                            Descricao = f.Descricao,
                            Telefone = f.Telefone,
                            Endereco = f.Endereco
                        };

                return q.ToList();
            }
        }

        public FornecedorBE GetFornecedor(int idFornecedor = 0)
        {

            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                var q = from f in db.Fornecedor
                        from ip in db.Imagem.Where(x => x.Id == f.ImagemPerfilId).DefaultIfEmpty()
                        join e in db.Etnia on f.EtniaId equals e.Id
                        //from ia in db.Avatar.Where(x => x.Id == f.ImagemAvatarId).DefaultIfEmpty()
                        join u in db.Usuario on f.UsuarioId equals u.Id
                        where f.Id == idFornecedor
                        //join a in context.Avatar on f.AvatarId equals a.Id
                        select new FornecedorBE()
                        {
                            Id = f.Id,
                            Etnia = new EtniaBE()
                            {
                                Id = e.Id,
                                DsEtnia = e.DsEtnia
                            },
                            //Idade = Idade(f.DtNascimento.Value),
                            Usuario = new UsuarioBE()
                            {
                                Id = u.Id,
                                Nome = u.Nome,
                                Email = u.Email,
                                Facebook = u.Facebook,
                                FlAtivo = u.FlAtivo.Value,
                                Login = u.Login
                            },
                            Idade = 23,
                            Altura = f.Altura.Value,
                            DtNascimento = f.DtNascimento.Value,
                            /*ImgPerfil = new ImagemBE(){                            
                                Id = ip.Id, 
                                UrlImagem = ip.UrlImagem
                            },*/
                            ImgPerfilId = ip.Id,
                            ImgPerfilUrl = ip.UrlImagem,
                            Latitude = f.Latitude,
                            Longitude = f.Longitude,
                            Nome = f.Nome,
                            Olhos = f.Olhos,
                            Preco = f.Preco,
                            Peso = f.Peso.Value,
                            Descricao = f.Descricao,
                            Telefone = f.Telefone,
                            Endereco = f.Endereco
                        };


                FornecedorBE fornecedor = (FornecedorBE)q.FirstOrDefault();

                if (fornecedor != null)
                {
                    var qi = from f in db.FotosPerfil
                             join i in db.Imagem on f.ImagemId equals i.Id
                             where f.FornecedorId == 5/*fornecedor.Id*/
                             select i;

                    fornecedor.Fotos = new List<ImagemBE>();

                    foreach (var img in (List<Imagem>)qi.ToList())
                    {
                        fornecedor.Fotos.Add(new ImagemBE(img.Id, img.UrlImagem));
                    }
                }

                return fornecedor;
            }
        }


        public int Incluir(FornecedorBE fornecedor)
        {
            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                Fornecedor f = new Fornecedor()
                {
                    Altura = fornecedor.Altura,
                    Descricao = fornecedor.Descricao,
                    DtNascimento = fornecedor.DtNascimento,
                    EtniaId = fornecedor.Etnia.Id,
                    ImagemAvatarId = fornecedor.ImgAvatarId,
                    ImagemPerfilId = fornecedor.ImgPerfilId.GetValueOrDefault(1),
                    Latitude = fornecedor.Latitude,
                    Longitude = fornecedor.Longitude,
                    Nome = fornecedor.Nome,
                    Olhos = fornecedor.Olhos,
                    Peso = fornecedor.Peso,
                    Preco = fornecedor.Preco,
                    Telefone = fornecedor.Telefone,
                    Endereco = fornecedor.Endereco,
                    //StatusId = fornecedor.StatusId
                    UsuarioId = new UsuarioDAL().Incluir(fornecedor.Usuario)
                };

                db.Fornecedor.Add(f);

                db.SaveChanges();

                return f.Id;
            }
        }

        public void Alterar(FornecedorBE fornecedor)
        {
            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                Fornecedor f = db.Fornecedor.Find(fornecedor.Id);

                f.Altura = fornecedor.Altura;
                f.Descricao = fornecedor.Descricao;
                f.DtNascimento = fornecedor.DtNascimento;
                f.EtniaId = fornecedor.Etnia.Id;
                f.ImagemAvatarId = fornecedor.ImgAvatarId;
                f.ImagemPerfilId = fornecedor.ImgPerfilId.GetValueOrDefault(1);
                f.Latitude = fornecedor.Latitude;
                f.Longitude = fornecedor.Longitude;
                f.Nome = fornecedor.Nome;
                f.Olhos = fornecedor.Olhos;
                f.Peso = fornecedor.Peso;
                f.Preco = fornecedor.Preco;
                f.Telefone = fornecedor.Telefone;
                f.Endereco = fornecedor.Endereco;
                //StatusId = fornecedor.StatusId                                               

                db.SaveChanges();

            }
        }

        public void Delete(int idFornecedor)
        {
            using (CAPITUDBEntities db = new CAPITUDBEntities())
            {
                Fornecedor f = db.Fornecedor.Find(idFornecedor);

                db.Fornecedor.Remove(f);
                db.SaveChanges();
            }
        }

    }
}
