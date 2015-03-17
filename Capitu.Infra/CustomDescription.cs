using System.ComponentModel;

namespace Capitu.Infra
{
    public class CustomDescription : DescriptionAttribute
    {
        public CustomDescription(string sigla, string descricao) : base(descricao)
        {
            Sigla = sigla;
        }

        public string Sigla { get; protected set; }
    }
}