using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace FormsUI
{
    public class EmailService
    {
        private static readonly string SenderEmail = "aldy.timbol@gmail.com";
        private static readonly string AppPassword = "gchzquaedqayzyub";
        private static readonly Dictionary<string, string> VerificationCodes = new Dictionary<string, string>();
        private static readonly Dictionary<string, DateTime> CodeExpirations = new Dictionary<string, DateTime>();

        public static bool SendVerificationCode(string recipientEmail)
        {
            try
            {
                string code = GenerateVerificationCode();

                VerificationCodes[recipientEmail] = code;
                CodeExpirations[recipientEmail] = DateTime.Now.AddMinutes(10);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SenderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Teleoplex - Password Reset Verification Code";
                    mail.Body = $@"
                        <html>
                        <body style='font-family: Arial, sans-serif;'>
                            <h2 style='color: #2563eb;'>Teleoplex Inventory System</h2>
                            <p>You requested to reset your password.</p>
                            <p>Your verification code is:</p>
                            <h1 style='color: #2563eb; letter-spacing: 5px;'>{code}</h1>
                            <p>This code will expire in 10 minutes.</p>
                            <p>If you did not request this, please ignore this email.</p>
                            <hr>
                            <p style='color: #64748b; font-size: 12px;'>Teleoplex Inventory Management System</p>
                        </body>
                        </html>
                    ";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(SenderEmail, AppPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool VerifyCode(string email, string code)
        {
            if (!VerificationCodes.ContainsKey(email))
                return false;

            if (!CodeExpirations.ContainsKey(email))
                return false;

            if (DateTime.Now > CodeExpirations[email])
            {
                VerificationCodes.Remove(email);
                CodeExpirations.Remove(email);
                return false;
            }

            bool isValid = VerificationCodes[email] == code;

            if (isValid)
            {
                VerificationCodes.Remove(email);
                CodeExpirations.Remove(email);
            }

            return isValid;
        }

        private static string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public static void ClearExpiredCodes()
        {
            var expiredEmails = new List<string>();
            foreach (var kvp in CodeExpirations)
            {
                if (DateTime.Now > kvp.Value)
                    expiredEmails.Add(kvp.Key);
            }

            foreach (var email in expiredEmails)
            {
                VerificationCodes.Remove(email);
                CodeExpirations.Remove(email);
            }
        }
    }
}