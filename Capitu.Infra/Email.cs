using System;
using System.Net;
using System.Net.Mail;

namespace Capitu.Infra
{
    /// <summary>
    /// Classe responsável pelos métodos de envio de email.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        public static void SendMail(string from, string fromName, string to, string toName, string subject, string body, bool isHTML)
        {
            SendMail(from, fromName, to, toName, subject, body, isHTML, string.Empty);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string to, string toName, string subject, string body, bool isHTML, string hostName)
        {
            SendMail(from, fromName, new string[] { to }, new string[] { toName }, subject, body, isHTML, hostName);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string to, string toName, string subject, string body, bool isHTML, string hostName, string userName, string password)
        {
            SendMail(from, fromName, new string[] { to }, new string[] { toName }, subject, body, isHTML, hostName, userName, password);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string subject, string body, bool isHTML)
        {
            SendMail(from, fromName, to, toName, subject, body, isHTML, string.Empty);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string subject, string body, bool isHTML, string hostName)
        {
            SendMail(from, fromName, to, toName, new string[] { }, new string[] { }, new string[] { }, new string[] { }, new string[] { }, subject, body, isHTML, hostName, null, null);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string subject, string body, bool isHTML, string hostName, string userName, string password)
        {
            SendMail(from, fromName, to, toName, new string[] { }, new string[] { }, new string[] { }, new string[] { }, new string[] { }, subject, body, isHTML, hostName, userName, password);
        }

        /// <summary>
        /// Envia um e-mail.
        /// </summary>
        /// <param name="from">Remetente do e-mail.</param>
        /// <param name="fromName">Nome do remetente do e-mail.</param>
        /// <param name="to">Destinatário do e-mail.</param>
        /// <param name="toName">Nome do destinatário do e-mail.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        /// <param name="isHTML">Indica se o conteúdo do e-mail é HTML.</param>
        /// <param name="attachments">Anexos ao e-mail.</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string subject, string body, bool isHTML, string[] attachments)
        {
            SendMail(from, fromName, to, toName, subject, body, isHTML, attachments, string.Empty);
        }

        /// <summary>
        /// Envia um e-mail.
        /// </summary>
        /// <param name="from">Remetente do e-mail.</param>
        /// <param name="fromName">Nome do remetente do e-mail.</param>
        /// <param name="to">Destinatário do e-mail.</param>
        /// <param name="toName">Nome do destinatário do e-mail.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        /// <param name="isHTML">Indica se o conteúdo do e-mail é HTML.</param>
        /// <param name="attachments">Anexos ao e-mail.</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string subject, string body, bool isHTML, string[] attachments, string hostName)
        {
            SendMail(from, fromName, to, toName, new string[] { }, new string[] { }, new string[] { }, new string[] { }, attachments, subject, body, isHTML, hostName, null, null);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'</param>
        /// <param name="ccName">Nome do endereço no campo 'cc'</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'</param>
        /// <param name="bccName">Nome do endereço no campo 'bcc'</param>
        /// <param name="attachmentFileNames">Caminhos dos anexos</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string[] cc, string[] ccName, string[] bcc, string[] bccName, string[] attachmentFileNames, string subject, string body, bool isHTML)
        {
            SendMail(from, fromName, to, toName, cc, ccName, bcc, bccName, attachmentFileNames, subject, body, isHTML, string.Empty, null, null);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'</param>
        /// <param name="ccName">Nome do endereço no campo 'cc'</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'</param>
        /// <param name="bccName">Nome do endereço no campo 'bcc'</param>
        /// <param name="attachmentFileNames">Caminhos dos anexos</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string[] cc, string[] ccName, string[] bcc, string[] bccName, string[] attachmentFileNames, string subject, string body, bool isHTML, string hostName, string userName, string password)
        {
            System.Net.Mail.MailAddress fromAddress;
            System.Net.Mail.MailAddress[] toAddress, ccAddress, bccAddress;
            System.Net.Mail.Attachment[] attachments;

            fromAddress = new System.Net.Mail.MailAddress(from, fromName);

            toAddress = new System.Net.Mail.MailAddress[to.Length];
            for (int i = 0; i < to.Length; i++)
            {
                toAddress[i] = new System.Net.Mail.MailAddress(to[i], toName[i]);
            }

            ccAddress = new System.Net.Mail.MailAddress[cc.Length];
            for (int i = 0; i < cc.Length; i++)
            {
                ccAddress[i] = new System.Net.Mail.MailAddress(cc[i], ccName[i]);
            }

            bccAddress = new System.Net.Mail.MailAddress[bcc.Length];
            for (int i = 0; i < bcc.Length; i++)
            {
                bccAddress[i] = new System.Net.Mail.MailAddress(bcc[i], bccName[i]);
            }

            attachments = new System.Net.Mail.Attachment[attachmentFileNames.Length];
            for (int i = 0; i < attachmentFileNames.Length; i++)
            {
                attachments[i] = new System.Net.Mail.Attachment(attachmentFileNames[i]);
            }

            if (userName == "" || userName == null && password == "" || password == null)
                SendMail(fromAddress, toAddress, ccAddress, bccAddress, attachments, subject, body, isHTML, hostName);
            else
                SendMail(fromAddress, toAddress, ccAddress, bccAddress, attachments, subject, body, isHTML, hostName, userName, password);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'</param>
        /// <param name="ccName">Nome do endereço no campo 'cc'</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'</param>
        /// <param name="bccName">Nome do endereço no campo 'bcc'</param>
        /// <param name="attachmentFiles">Array de Anexos</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string[] cc, string[] ccName, string[] bcc, string[] bccName, System.Net.Mail.Attachment[] attachmentFiles, string subject, string body, bool isHTML)
        {
            SendMail(from, fromName, to, toName, cc, ccName, bcc, bccName, attachmentFiles, subject, body, isHTML, string.Empty);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente</param>
        /// <param name="fromName">Nome do remetente</param>
        /// <param name="to">Endereço de e-mail no campo 'para'</param>
        /// <param name="toName">Nome do endereço no campo 'para'</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'</param>
        /// <param name="ccName">Nome do endereço no campo 'cc'</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'</param>
        /// <param name="bccName">Nome do endereço no campo 'bcc'</param>
        /// <param name="attachmentFiles">Array de Anexos</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="body">Corpo do e-mail</param>
        /// <param name="isHTML">Indica se o corpo é html</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(string from, string fromName, string[] to, string[] toName, string[] cc, string[] ccName, string[] bcc, string[] bccName, System.Net.Mail.Attachment[] attachmentFiles, string subject, string body, bool isHTML, string hostName)
        {
            System.Net.Mail.MailAddress fromAddress;
            System.Net.Mail.MailAddress[] toAddress, ccAddress, bccAddress;

            fromAddress = new System.Net.Mail.MailAddress(from, fromName);

            toAddress = new System.Net.Mail.MailAddress[to.Length];
            for (int i = 0; i < to.Length; i++)
            {
                toAddress[i] = new System.Net.Mail.MailAddress(to[i], toName[i]);
            }

            ccAddress = new System.Net.Mail.MailAddress[cc.Length];
            for (int i = 0; i < cc.Length; i++)
            {
                ccAddress[i] = new System.Net.Mail.MailAddress(cc[i], ccName[i]);
            }

            bccAddress = new System.Net.Mail.MailAddress[bcc.Length];
            for (int i = 0; i < bcc.Length; i++)
            {
                bccAddress[i] = new System.Net.Mail.MailAddress(bcc[i], bccName[i]);
            }

            SendMail(fromAddress, toAddress, ccAddress, bccAddress, attachmentFiles, subject, body, isHTML, hostName);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente.</param>
        /// <param name="to">Endereço de e-mail no campo 'para'.</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'.</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'.</param>
        /// <param name="attachment">Anexos ao e-mail.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        /// <param name="isHTML">Indica se o corpo é html.</param>
        public static void SendMail(System.Net.Mail.MailAddress from, System.Net.Mail.MailAddress[] to, System.Net.Mail.MailAddress[] cc, System.Net.Mail.MailAddress[] bcc, System.Net.Mail.Attachment[] attachment, string subject, string body, bool isHTML)
        {
            SendMail(from, to, cc, bcc, attachment, subject, body, isHTML, string.Empty);
        }

        /// <summary>
        /// Envia um e-mail
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente.</param>
        /// <param name="to">Endereço de e-mail no campo 'para'.</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'.</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'.</param>
        /// <param name="attachment">Anexos ao e-mail.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        /// <param name="isHTML">Indica se o corpo é html.</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(System.Net.Mail.MailAddress from, System.Net.Mail.MailAddress[] to, System.Net.Mail.MailAddress[] cc, System.Net.Mail.MailAddress[] bcc, System.Net.Mail.Attachment[] attachment, string subject, string body, bool isHTML, string hostName)
        {
            using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
            {
                System.Net.Mail.SmtpClient smtp = null;

                if (!string.IsNullOrEmpty(hostName))
                    smtp = new System.Net.Mail.SmtpClient(hostName);
                else
                    smtp = new System.Net.Mail.SmtpClient();

                smtp.UseDefaultCredentials = true;

                msg.From = from;

                for (int i = 0; i < to.Length; i++)
                {
                    msg.To.Add(to[i]);
                }

                for (int i = 0; i < cc.Length; i++)
                {
                    msg.CC.Add(cc[i]);
                }

                for (int i = 0; i < bcc.Length; i++)
                {
                    msg.Bcc.Add(bcc[i]);
                }

                for (int i = 0; i < attachment.Length; i++)
                {
                    msg.Attachments.Add(attachment[i]);
                }

                msg.IsBodyHtml = isHTML;
                msg.Subject = subject;
                msg.Body = body;

                try
                {
                    smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                smtp = null;
            }
        }

        /// <summary>
        /// Envia um e-mail passando as credentials
        /// </summary>
        /// <param name="from">Endereço de e-mail do remetente.</param>
        /// <param name="to">Endereço de e-mail no campo 'para'.</param>
        /// <param name="cc">Endereço de e-mail no campo 'cc'.</param>
        /// <param name="bcc">Endereço de e-mail no campo 'bcc'.</param>
        /// <param name="attachment">Anexos ao e-mail.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        /// <param name="isHTML">Indica se o corpo é html.</param>
        /// <param name="hostName">Servidor Email</param>
        public static void SendMail(System.Net.Mail.MailAddress from, System.Net.Mail.MailAddress[] to, System.Net.Mail.MailAddress[] cc, System.Net.Mail.MailAddress[] bcc, System.Net.Mail.Attachment[] attachment, string subject, string body, bool isHTML, string hostName, string userName, string password)
        {
            using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
            {
                System.Net.Mail.SmtpClient smtp = null;

                if (!string.IsNullOrEmpty(hostName))
                    smtp = new System.Net.Mail.SmtpClient(hostName);
                else
                    smtp = new System.Net.Mail.SmtpClient();

                smtp.Credentials = new NetworkCredential(userName, password);

                //xxx  quando for outlook comentar essas 2 linhas  xxx
                smtp.EnableSsl = false;
                smtp.Port = 2525;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

                msg.From = from;

                for (int i = 0; i < to.Length; i++)
                {
                    msg.To.Add(to[i]);
                }

                for (int i = 0; i < cc.Length; i++)
                {
                    msg.CC.Add(cc[i]);
                }

                for (int i = 0; i < bcc.Length; i++)
                {
                    msg.Bcc.Add(bcc[i]);
                }

                for (int i = 0; i < attachment.Length; i++)
                {
                    msg.Attachments.Add(attachment[i]);
                }

                msg.IsBodyHtml = isHTML;
                msg.Subject = subject;
                msg.Body = body;

                try
                {
                    smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                smtp = null;
            }
        }
    }
}
