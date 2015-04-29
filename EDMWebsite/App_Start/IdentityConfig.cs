using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EDMWebsite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EDMWebsite
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return configSendGridasync(message);
        }
        private Task configSendGridasync(IdentityMessage message)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(message.Destination);
            mailMessage.From = new System.Net.Mail.MailAddress(
                                "123439887@qq.com", "项目名称.");
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = true;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.qq.com";
            smtp.Credentials = credentials;
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.SendCompleted += smtp_SendCompleted;

            return smtp.SendMailAsync(mailMessage);
        }

        void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //MailMessage mailMsg = (MailMessage)e.UserState;
            //string subject = mailMsg.Subject;
            var result = string.Empty;
            if (e.Cancelled) // 邮件被取消 
            {
                result = " 被取消。";
            }
            if (e.Error != null)
            {
                result = "错误：" + e.Error.ToString();
            }
            else
            {
                result = "发送完成。";
            }
        }

    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
