/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * SecureEmailService class. Deals with operations related to
 * sending reset password verification code via user email
 * Doesn't implement an interface
 **/


using ItemDataLibrary.Configuration;
using ItemDataLibrary.Models;
using ItemDataLibrary.Security;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ITS152L_Project.Services.Implementations
{
    public class SecureEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly ItemApiContext _context;

        //Validates secrets
        public SecureEmailService(
            IOptions<EmailConfiguration> emailConfig,
            IPasswordResetTokenRepository tokenRepository,
            ItemApiContext context)
        {
            _emailConfig = emailConfig.Value;
            _tokenRepository = tokenRepository;
            _context = context;

            if (string.IsNullOrWhiteSpace(_emailConfig.SenderEmail))
                throw new InvalidOperationException("Email sender address not configured");
            if (string.IsNullOrWhiteSpace(_emailConfig.AppPassword))
                throw new InvalidOperationException("Email app password not configured");
        }

        //Sends verification to registered user email
        public async Task<bool> SendVerificationCodeAsync(UserModel user)
        {
            try
            {
                string token = SecureTokenService.GenerateUniqueToken(_context);
                await _tokenRepository.CreateTokenAsync(user.Id, token, expiryMinutes: 10);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_emailConfig.SenderEmail);
                    mail.To.Add(user.UserName);
                    mail.Subject = "Teleoplex - Password Reset Verification Code";
                    mail.Body = GenerateEmailBody(user.FirstName, token);
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(_emailConfig.SenderEmail, _emailConfig.AppPassword);
                        smtp.EnableSsl = _emailConfig.EnableSsl;
                        await smtp.SendMailAsync(mail);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Verifies verification code
        public async Task<bool> VerifyCodeAsync(int userId, string code)
        {
            if (!SecureTokenService.IsValidTokenFormat(code))
                return false;

            var token = _context.PasswordResetTokens
                .FirstOrDefault(t => t.UserId == userId && t.Token == code && !t.IsUsed && t.Expiry > DateTime.UtcNow);

            if (token == null)
                return false;

            await _tokenRepository.MarkTokenAsUsedAsync(token.Id);
            return true;
        }

        public async Task CleanupExpiredTokensAsync()
        {
            await _tokenRepository.DeleteExpiredTokensAsync();
        }

        //Generates email message
        private string GenerateEmailBody(string firstName, string token)
        {
            return $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .header {{ background-color: #2563eb; color: white; padding: 20px; text-align: center; border-radius: 8px 8px 0 0; }}
                        .content {{ background-color: #f8f9fa; padding: 30px; border-radius: 0 0 8px 8px; }}
                        .token {{ font-size: 32px; font-weight: bold; letter-spacing: 8px; color: #2563eb; text-align: center; padding: 20px; background-color: white; border-radius: 8px; margin: 20px 0; }}
                        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #dee2e6; color: #6c757d; font-size: 12px; text-align: center; }}
                        .warning {{ background-color: #fff3cd; border-left: 4px solid #ffc107; padding: 12px; margin: 15px 0; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>🔐 TELEOPLEX</h1>
                            <p>Inventory Management System</p>
                        </div>
                        <div class='content'>
                            <h2>Hello {firstName}!</h2>
                            <p>We received a request to reset your password. Use the verification code below to proceed:</p>
                            <div class='token'>{token}</div>
                            <div class='warning'>
                                <strong>Security Notice:</strong>
                                <ul style='margin: 10px 0; padding-left: 20px;'>
                                    <li>This code will expire in <strong>10 minutes</strong></li>
                                    <li>The code can only be used <strong>once</strong></li>
                                    <li>Never share this code with anyone</li>
                                </ul>
                            </div>
                            <p>If you didn't request this password reset, please ignore this email and your password will remain unchanged.</p>
                            <p style='margin-top: 30px;'>
                                <strong>Need help?</strong><br>
                                Contact your system administrator if you continue to experience issues.
                            </p>
                        </div>
                        <div class='footer'>
                            <p>This is an automated message from Teleoplex Inventory Management System</p>
                            <p>© {DateTime.Now.Year} Teleoplex. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";
        }
    }
}
