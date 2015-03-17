using System;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Capitu.Infra
{
    public static class StringExtension
    {
        private static Random _random;

        public static Random Random
        {
            get { return _random ?? (_random = new Random()); }
        }

        private static Tuple<byte[], byte[]> InitializeRijndael()
        {
            var key = new byte[] { 0x33, 0x13, 0x82, 0x46, 0x0d, 0x90, 0x2d, 0x13, 0x41, 0xdc, 0x73, 0xdb, 0x8b, 0x99, 0x0f, 0x97 };
            var iv = new byte[] { 0x25, 0xc5, 0x21, 0x3d, 0xad, 0xeb, 0xf8, 0x13, 0xd3, 0x6d, 0x47, 0x00, 0x70, 0xb6, 0x00, 0x2c };

            return Tuple.Create(key, iv);
        }

        public static string Encrypt(this int intVal)
        {
            return intVal.ToString().Encrypt();
        }

        public static string EncryptUrl(this int intVal, int id)
        {
            return intVal.ToString().EncryptUrl(id);
        }

        public static string EncryptUrl(this string str, int idUsuario)
        {
            var tuple = new Tuple<string, int>(str, idUsuario);

            return Encrypt(tuple.ToJson());
        }

        public static string DecryptUrl(this int intVal, int id)
        {
            return DecryptUrl(intVal.ToString(), id);
        }

        public static string DecryptUrl(this string str, int id)
        {
            var obj = str.Decrypt().FromJson<Tuple<string, int>>();

            if (obj.Item2 != id)
            {
                throw new SecurityException("id do usuário logado inválido");
            }

            return obj.Item1;
        }

        public static string Encrypt(this string str)
        {
            byte[] input, output;
            RijndaelManaged rijndael;
            ICryptoTransform encryptor;
            Tuple<byte[], byte[]> tuple;

            var buffer = new byte[2];

            Random.NextBytes(buffer);

            var salt = ByteArrayToString(buffer);

            using (rijndael = new RijndaelManaged())
            {
                tuple = InitializeRijndael();

                using (encryptor = rijndael.CreateEncryptor(tuple.Item1, tuple.Item2))
                {
                    input = Encoding.UTF8.GetBytes(salt + str);
                    output = encryptor.TransformFinalBlock(input, 0, input.Length);
                }
            }

            return ByteArrayToString(output);
        }

        public static string Decrypt(this string str)
        {
            byte[] input, output;
            RijndaelManaged rijndael;
            ICryptoTransform decryptor;
            Tuple<byte[], byte[]> tuple;

            using (rijndael = new RijndaelManaged())
            {
                tuple = InitializeRijndael();

                using (decryptor = rijndael.CreateDecryptor(tuple.Item1, tuple.Item2))
                {
                    input = StringToByteArray(str);
                    output = decryptor.TransformFinalBlock(input, 0, input.Length);
                }
            }

            var decrypt = Encoding.UTF8.GetString(output);

            return decrypt.Substring(4, decrypt.Length - 4);
        }

        public static string FormataMoeda(this decimal valor, int casas)
        {
            return valor.ToString("N" + casas);
        }


        public static string FormataDocumento(this string documento)
        {
            if (documento.Length <= 11)
                return FormataCpf(documento);

            return FormataCnpj(documento);
        }

        public static string FormataCnpj(this string cnpj)
        {
            return String.Format(new CustomerFormatter(), "{0:cnpj}", cnpj);
        }

        public static string FormataCpf(this string cpf)
        {
            return String.Format(new CustomerFormatter(), "{0:cpf}", cpf);
        }

        public static bool EmailValido(this string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (regex.IsMatch(email))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Funciona para CPF, CNPJ e Placa
        /// </summary>
        /// <param name="documento">Documento a que terá a formatação removida</param>
        /// <returns>Documento sem formatação</returns>
        public static string RemoverMascaras(this string documento)
        {
            return documento != null ? documento.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "") : documento;
        }

        public static string RemoverAcentos(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return "";
            }

            var normalizado = texto.Normalize(NormalizationForm.FormD);

            var array = normalizado.ToCharArray();

            var semAcentos = array.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);

            var retorno = new string(semAcentos.ToArray());

            return retorno;
        }

        private static byte[] StringToByteArray(string str)
        {
            return Enumerable.Range(0, str.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                .ToArray();
        }

        private static string ByteArrayToString(byte[] array)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                sb.Append(array[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static bool Hexadecimal(this string valor)
        {
            Regex regex = new Regex(RegularExpressionHelper.Hexadecimal);

            if (regex.IsMatch(valor))
            {
                return true;
            }

            return false;
        }

        public static string Truncate(this string str, int length, char padding, bool toLeft = true)
        {
            if (string.IsNullOrEmpty(str))
                str = string.Empty;

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }

            if (toLeft)
                return str.PadLeft(length, padding);

            return str.PadRight(length, padding);
        }

        public static string Truncate(this int? i, int length, char padding, bool toLeft = true)
        {
            if (i != null)
            {
                var str = i.Value.ToString(CultureInfo.InvariantCulture);

                return Truncate(str, length, padding, toLeft);
            }

            return null;
        }

        public static string Truncate(this long? i, int length, char padding, bool toLeft = true)
        {
            if (i != null)
            {
                var str = i.Value.ToString(CultureInfo.InvariantCulture);

                return Truncate(str, length, padding, toLeft);
            }

            return null;
        }

        public static string Truncate(this decimal? i, int length, char padding, bool toLeft = true)
        {
            if (i != null)
            {
                i = Math.Round(i.Value * 100, 0);

                var str = i.Value.ToString(CultureInfo.InvariantCulture);

                return Truncate(str, length, padding, toLeft);
            }

            return null;
        }

        public static string Truncate(this int i, int length, char padding, bool toLeft = true)
        {
            var str = i.ToString(CultureInfo.InvariantCulture);

            return Truncate(str, length, padding, toLeft);
        }

        public static bool ValidarFormatoPlaca(this string placa)
        {
            return Regex.IsMatch(placa, @"^[A-Z]{3}\-[0-9]{4}$");
        }

        public static string TrataNomeCompletoParaEnvio(this string nome)
        {
            var nomeCompleto = (nome.Length > 40) ? nome.Substring(0, 39) : nome;

            return nomeCompleto.ToUpper();
        }

        public static int TryParseInt(this string numero)
        {
            var result = 0;
            int.TryParse(numero, out result);
            return result;
        }

    }
}
