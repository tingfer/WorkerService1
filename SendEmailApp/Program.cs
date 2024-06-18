using Outlook = Microsoft.Office.Interop.Outlook;

namespace SendEmailApp
{

    class Program
    {
        static void Main()
        {
            try
            {
                // 创建 Outlook 应用程序对象
                Outlook.Application outlookApp = new();

                // 创建邮件项
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                // 设置邮件项属性
                mailItem.Subject = "Test Email";
                mailItem.Body = "This is a test email sent using Outlook and C#.";
                mailItem.To = "oliver.lin@tm-robot.com"; // 设置收件人地址，可以是多个地址，使用逗号分隔
                                                       // 如果需要抄送（CC）或密送（BCC），可以设置以下属性：
                                                       // mailItem.CC = "cc_recipient@example.com";
                                                       // mailItem.BCC = "bcc_recipient@example.com";

                // 发送邮件
                mailItem.Send();

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email. Error message: " + ex.Message);
            }
        }
    }

}
