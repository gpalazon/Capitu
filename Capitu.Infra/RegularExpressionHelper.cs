namespace Capitu.Infra
{
    public class RegularExpressionHelper
    {
        public const string CEP = @"^\d{5}-\d{3}$";
        public const string Hexadecimal = @"^([A-F0-9]{16})$";
        public const string Placa = @"^[a-zA-Z]{3}\-\d{4}$";
        public const string Numero = @"^\d+$";
        public const string Email = @"^[A-Za-z0-9]+[a-zA-Z0-9\.\-_]*@([\-]*[a-zA-Z0-9]+)+(\.+[\-]*[a-zA-Z0-9]+)*\.[A-Za-z]{2,}$";
        public const string NaoPermitirCaracterEspecial = @"^[a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄÇç0-9.\s]*$";
        public const string NaoPermitirCaracterEspecialNemNumeros = @"^[a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄÇç\s]*$";
        public const string NaoPermitirCaracterEspecialNemPontos = @"^[a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄÇç0-9\s]*$";
        public const string PermitirSomenteLetrasENumeros = @"^[\w]*$";
        public const string UNC = @"^[a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄÇç0-9_.\\:\s\$\!\-]*$";
        public const string CPF = @"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)";
        public const string CpfCnpj = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)|(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)";
        public const string DDD = @"^(?:[0-9]{0}|[0-9]{2})$";
        public const string Telefone = @"^(?:[0-9]{0}|[0-9]{8,9})$";
        public const string Hora = @"^([0-1][0-9]|[2][0-3]):[0-5][0-9]$";
        public const string Senha = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z\!\@\#\$\%\&\*\)\(\-_\,\.\;\:\+\=\}\{\[\]\?\<\>\|\/\\]*$";
        public const string SomenteLetras = @"^[a-zA-Z\s]*$";
    }
}
