using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;

/// <summary>
///NetMail 的摘要说明
/// </summary>
public class NetMail
{
    public NetMail() { }

    #region model
    /// <summary>
    /// 发件人地址
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// 发件人名称
    /// </summary>
    public string Fromer { get; set; }

    /// <summary>
    /// 收件人地址
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// 收件人名称
    /// </summary>
    public string Toer { get; set; }

    /// <summary>
    /// 邮件主题
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// 邮件内容
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// SMTP服务器
    /// </summary>
    public string SMTP { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string PassWord { get; set; }

    /// <summary>
    /// 附件
    /// </summary>
    public string attachment { get; set; }

    /// <summary>
    /// 抄送
    /// </summary>
    public string Cc { get; set; }
    #endregion

    public bool SenMail()
    {

        try
        {
            //SmtpClient下的一个对象，用以设置邮件的主题和内容   
            MailMessage myMail = new MailMessage();

            string[] arryto = To.Split(';');
            for (int i = 0; i < arryto.Length; i++)
            {
                string toer = arryto[i];

                //发送端到接收端的邮箱地址   
                myMail = new MailMessage(From, toer);
                myMail.Subject = Subject;
                myMail.Body = Body;
                if (!string.IsNullOrEmpty(Cc))
                    myMail.Bcc.Add(Cc);
                if (!string.IsNullOrEmpty(attachment))
                {
                    string[] fileList = attachment.Split(';');
                    for (int j = 0; j < fileList.Length; j++)
                    {
                        string file = fileList[j];
                        Attachment myAttachment = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);

                        //MIME协议下的一个对象，用以设置附件的创建时间，修改时间以及读取时间   
                        ContentDisposition disposition = myAttachment.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(file);
                        disposition.ModificationDate = File.GetLastWriteTime(file);
                        disposition.ReadDate = File.GetLastAccessTime(file);

                        //用smtpclient对象里attachments属性，添加上面设置好的myattachment   
                        myMail.Attachments.Add(myAttachment);
                    }
                }
                //建立发送对象client,验证邮件服务器，服务器端口，用户名，以及密码   
                SmtpClient client = new SmtpClient(SMTP);

                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(From, PassWord);
                client.Send(myMail);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        return true;
    }
}
