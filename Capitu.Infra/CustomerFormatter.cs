using System;

namespace Capitu.Infra
{
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider) || arg == null)
                return null;

            var customerString = arg.ToString();
            if (String.IsNullOrEmpty(customerString))
            {
                return String.Empty;
            }
            format = format.ToLower();
            try
            {
                switch (format)
                {
                    case "cpf":
                        customerString = customerString.Replace(".", "").Replace("-", "");
                        long cpf;
                        if (long.TryParse(customerString, out cpf))
                            customerString = String.Format(@"{0:000\.000\.000\-00}", cpf);
                        return customerString;

                    case "cnpj":
                        customerString = customerString.Replace(".", "").Replace("/", "").Replace("-", "");
                        long cnpj;
                        if (long.TryParse(customerString, out cnpj))
                            customerString = String.Format(@"{0:00\.000\.000\/0000\-00}", cnpj);
                        return customerString;

                    case "placa":
                        customerString = customerString.Replace("-", "");
                        customerString = customerString.Substring(0, 3) + "-" + customerString.Substring(3, 4);
                        return customerString;

                    case "cep":
                        customerString = customerString.Replace("-", "");
                        customerString = customerString.Substring(0, 5) + "-" + customerString.Substring(5, 3);
                        return customerString;

                    case "telefone":
                        customerString = customerString.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
                        long telefone;
                        if (long.TryParse(customerString, out telefone))
                        {
                            if (customerString.Length == 11)
                                customerString = String.Format(@"{0:\(00\) 00000\-0000}", telefone);
                            else
                                customerString = String.Format(@"{0:\(00\) 0000\-0000}", telefone);
                        }
                        return customerString;

                    default:
                        throw new FormatException(
                            String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
            catch (Exception)
            {
                throw new FormatException(string.Format("Valor {0} é inválido para o formato \"{1}\"", customerString, format));
            }
        }
    }
}
