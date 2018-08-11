using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;


namespace Utils工具
{
    public static class MailHelper
    {
        private readonly static string SmtpServer;//发送服务器
        private readonly static int SmtpServerPort;//端口
        private readonly static bool SmtpEnableSsl;//是否启用SSL
        private readonly static string SmtpUsername;//用户名
        private readonly static string SmtpDisplayName;//显示名称
        private readonly static string SmtpPassword;//密码

        static MailHelper()
        {
            SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            SmtpServerPort =Convert.ToInt32(ConfigurationManager.AppSettings["SmtpServerPort"]);
            SmtpEnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpEnableSsl"]);
            SmtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            SmtpDisplayName = ConfigurationManager.AppSettings["SmtpDisplayName"];
            SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        }

        /// <summary>
        /// 发送邮件到指定收件人
        /// </summary>
        /// <param name="to">收件人地址</param>
        /// <param name="subject">主题</param>
        /// <param name="mailBody">正文内容(支持HTML)</param>
        /// <param name="copyTos">抄送地址列表</param>
        /// <returns>是否发送成功</returns>
        public static bool Send(string to, string subject, string mailBody, params string[] copyTos)
        {
            return Send(new[] { to }, subject, mailBody, copyTos, new string[] { }, MailPriority.Normal);
        }

        /// <summary>
        /// 发送邮件到指定收件人
        /// </summary>
        /// <param name="tos">收件人地址列表</param>
        /// <param name="subject">主题</param>
        /// <param name="mailBody">正文内容(支持HTML)</param>
        /// <param name="ccs">抄送地址列表</param>
        /// <param name="bccs">密件抄送地址列表</param>
        /// <param name="priority">此邮件的优先级</param>
        /// <param name="attachments">附件列表</param>
        /// <returns>是否发送成功</returns>
        /// <exception cref="System.ArgumentNullException">attachments</exception>
        public static bool Send(string[] tos, string subject, string mailBody, string[] ccs, string[] bccs, MailPriority priority, params Attachment[] attachments)
        {
            if (attachments == null) throw new ArgumentNullException("attachments");
            if (tos.Length == 0) return false;
            //创建Email实体
            var message = new MailMessage();
            message.From = new MailAddress(SmtpUsername, SmtpDisplayName,System.Text.Encoding.UTF8);
            message.Subject = subject;
            message.Body = mailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = priority;
            //插入附件
            foreach (var attachment in attachments)
            {
                message.Attachments.Add(attachment);
            }
            //插入收件人地址,抄送地址和密件抄送地址
            foreach (var to in tos.Where(c => !string.IsNullOrEmpty(c)))
            {
                message.To.Add(new MailAddress(to));
            }
            foreach (var cc in ccs.Where(c => !string.IsNullOrEmpty(c)))
            {
                message.CC.Add(new MailAddress(cc));
            }
            foreach (var bcc in bccs.Where(c => !string.IsNullOrEmpty(c)))
            {
                message.CC.Add(new MailAddress(bcc));
            }
            //创建SMTP客户端
            var client = new SmtpClient
            {
                Host = SmtpServer,
                Credentials = new System.Net.NetworkCredential(SmtpUsername, SmtpPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = SmtpEnableSsl,
                Port = SmtpServerPort
            };
            //发送邮件
            client.Send(message);
            return true;
        }
    }
}
