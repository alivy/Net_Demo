using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Utils工具
{
    public  class Email
    {
        public string  SendMail()
        {
            string mailAddress = "1562547198@qq.com";  //发件人地址，就是你的邮箱地址。
            string fromAddress = "qft@qianft.com";    //邮件服务器，如mail.qq.com
            string mailHost = "smtp.exmail.qq.com";  //smtp.qq.com
            //string pwd = "yanhaomiao123";            //"Qft201701"
            string code = "weoqifnomtybbggb";
            MailMessage objMailMessage = new MailMessage
            {
                From = new MailAddress(fromAddress, "钱富通", System.Text.Encoding.UTF8),//发送方地址
                Subject = "测试邮件",       //邮件标题
                Body = "这是一个测试邮件",  //邮件内容
                BodyEncoding = Encoding.UTF8,//邮件编码
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true,          //邮件正文是否为html格式             
                Priority = MailPriority.Normal //设置优先级
            };
            objMailMessage.To.Add(new MailAddress(mailAddress));//收信人地址
            SmtpClient objSmtpClient = new SmtpClient
            {
                Host = mailHost,//邮件服务器地址
                DeliveryMethod = SmtpDeliveryMethod.Network,//通过网络发送到stmp邮件服务器
                Credentials = new System.Net.NetworkCredential(fromAddress, code),//发送方的邮件地址，密码
                EnableSsl = true,
                Port = 25
            };
            //objSmtpClient.EnableSsl = true;//SMTP 服务器要求安全连接需要设置此属性
            try
            {
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                Logger.WirteLocalMessageLog("邮件发送异常" + ex.ToString());//记录错误日志
            }
            return "OK";
        }
    }
}
