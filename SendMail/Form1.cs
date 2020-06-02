using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendGmail();
        }

        public void sendGmail()
        {
            try
            {
                //設定SMTP資訊
                SmtpClient smtpSetting = new SmtpClient("smtp-mail.outlook.com", 587); // Gmail(Port為25或587皆可)
                                                                            /*
                                                                           Yahoo(Port為25或587皆可)
                                                                           SmtpClient smtpSetting = new SmtpClient("smtp.mail.yahoo.com.tw", 587);  

                                                                           Hotmail(Port為25或587皆可)
                                                                           SmtpClient smtpSetting = new SmtpClient("smtp-mail.outlook.com", 587);  
                                                                           */
            smtpSetting.Credentials = new NetworkCredential("寄信人", "密碼");
            smtpSetting.EnableSsl = true;

            //設定信件內容
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("信箱", "寄信人名稱");
            msg.To.Add("收信人");
            //msg.CC.Add("副本收件者的電子郵件");
            msg.Subject = "信件主旨";
            msg.Body = "<h1><font color=blue>信件內容</font><br/>";
            msg.IsBodyHtml = true; // 是否使用HTML格式
            msg.BodyEncoding = UTF8Encoding.UTF8; // 電子郵件編瑪

            //寄出電子郵件
            smtpSetting.Send(msg);
            }     
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
