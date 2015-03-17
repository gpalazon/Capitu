using System;
using System.Text;

namespace Capitu.Infra
{
    public static class Senha
    {
        #region Mensagens de Erro

        private static readonly string RegraIndefinida = "A senha deve conter ao menos uma regra aplicada.";
        private static readonly string RegraInvalida = "O número de regras definidas não se aplicam ao tamanho da senha.";

        #endregion

        private static readonly string _letrasMinusculas = "qwertyuiopasdfghjklzxcvbnm";
        private static readonly string _letrasMaiusculas = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private static readonly string _numeros = "1234567890";
        private static readonly string _caracteresEspeciais = "!@#$%&";

        public static string GerarSenha(bool caracteresEspeciais, bool minusculas, bool maiusculas, bool numeros, int tamanho)
        {
            var totalDeRegras = 0;

            if (caracteresEspeciais)
                totalDeRegras++;

            if (minusculas)
                totalDeRegras++;

            if (maiusculas)
                totalDeRegras++;

            if (numeros)
                totalDeRegras++;

            if(totalDeRegras == 0)
                throw new Exception(RegraIndefinida);

            if (tamanho < totalDeRegras)
                throw new Exception(RegraInvalida);

            var caracteres = "";

            caracteres += (minusculas) ? _letrasMinusculas : string.Empty;
            caracteres += (maiusculas) ? _letrasMaiusculas : string.Empty;
            caracteres += (numeros) ? _numeros : string.Empty;
            caracteres += (caracteresEspeciais) ? _caracteresEspeciais : string.Empty;

            var random = new Random();
            var senha = new StringBuilder();

            if (caracteresEspeciais)
                senha.Append(_caracteresEspeciais[random.Next(0, _caracteresEspeciais.Length)]);

            if (minusculas)
                senha.Append(_letrasMinusculas[random.Next(0, _letrasMinusculas.Length)]);

            if (maiusculas)
                senha.Append(_letrasMaiusculas[random.Next(0, _letrasMaiusculas.Length)]);

            if (numeros)
                senha.Append(_numeros[random.Next(0, _numeros.Length)]);

            var restante = tamanho - senha.Length;

            for (int i = 0; i < restante; i++)
            {
                senha.Append(caracteres[random.Next(0, caracteres.Length)]);
            }
              
            return senha.ToString();
        }
    }
}
