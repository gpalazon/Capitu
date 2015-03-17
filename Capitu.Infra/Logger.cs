using System;
using log4net;
using log4net.Config;

namespace Capitu.Infra
{
    /// <summary>
    /// Classe responsável por criar o log do sistema.
    /// </summary>
    public class Logger
    {

        /// <summary>
        /// Variavel utilizada para criação do log de execução do web service.
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// Construtor: Inicializa as variáveis necessárias para execução do log.
        /// </summary>
        static Logger()
        {
            try
            {
                var fi = new System.IO.FileInfo(string.Format(@"{0}\Log4net.config", AppDomain.CurrentDomain.BaseDirectory));
                fi.OpenRead();
                XmlConfigurator.Configure(fi);
            }
            catch{}
        }

        /// <summary>
        /// Cria um log do tipo debug.
        /// </summary>
        /// <param name="message">Mensagem a ser logada.</param>
        public static void Debug(object message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Cria um log do tipo debug.
        /// </summary>
        /// <param name="format">Mensagem a ser logada com os indices dos parametros passados no parâmetro args.</param>
        /// <param name="args">Argumentos.</param>
        public static void DebugFormat(string format, params object[] args)
        {
            logger.DebugFormat(format, args);
        }

        /// <summary>
        /// Cria um log do tipo informativo.
        /// </summary>
        /// <param name="message">Mensagem a ser logada.</param>
        public static void Info(object message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Cria um log do tipo informativo.
        /// </summary>
        /// <param name="format">Mensagem a ser logada com os indices dos parametros passados no parâmetro args.</param>
        /// <param name="args">Argumentos.</param>
        public static void InfoFormat(string format, params object[] args)
        {
            logger.InfoFormat(format, args);
        }

        /// <summary>
        /// Cria um log do tipo erro.
        /// </summary>
        /// <param name="message">Mensagem a ser logada.</param>
        public static void Error(object message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Cria um log do tipo erro.
        /// </summary>
        /// <param name="format">Mensagem a ser logada com os indices dos parametros passados no parâmetro args.</param>
        /// <param name="args">Argumentos.</param>
        public static void ErrorFormat(string format, params object[] args)
        {
            logger.ErrorFormat(format, args);
        }

        /// <summary>
        /// Cria um log do tipo Fatal.
        /// </summary>
        /// <param name="message">Mensagem a ser logada.</param>
        public static void Fatal(object message)
        {
            logger.Fatal(message);
        }

        /// <summary>
        /// Cria um log do tipo fatal.
        /// </summary>
        /// <param name="format">Mensagem a ser logada com os indices dos parametros passados no parâmetro args.</param>
        /// <param name="args">Argumentos.</param>
        public static void FatalFormat(string format, params object[] args)
        {
            logger.FatalFormat(format, args);
        }

        /// <summary>
        /// Cria um log do tipo Warn (Atenção).
        /// </summary>
        /// <param name="message">Mensagem a ser logada.</param>
        public static void Warn(object message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Cria um log do tipo Warn (Atenção).
        /// </summary>
        /// <param name="format">Mensagem a ser logada com os indices dos parametros passados no parâmetro args.</param>
        /// <param name="args">Argumentos.</param>
        public static void WarnFormat(string format, params object[] args)
        {
            logger.WarnFormat(format, args);
        }
    }
}
