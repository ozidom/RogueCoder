using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace RogueCoder.Utility
{
    public class Utility
    {
        public static void SendNotificationEmail(string title,string subject)
        {
            WebMail.SmtpServer = "smtp.domssite.com";
            WebMail.Password = "cricket";
            WebMail.UserName = "emailnotification@domssite.com";
            WebMail.Send("dommillar@gmail.com",title,subject,"emailnotification@domssite.com",null,null,true);

        }
    }
}