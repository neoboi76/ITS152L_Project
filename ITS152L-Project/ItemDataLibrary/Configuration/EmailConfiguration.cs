namespace ItemDataLibrary.Configuration
{
    /// <summary>
    /// Email service configuration settings
    /// Values loaded from User Secrets or environment variables
    /// </summary>
    public class EmailConfiguration
    {
        public string SenderEmail { get; set; } = null!;
        public string AppPassword { get; set; } = null!;
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public bool EnableSsl { get; set; } = true;
    }
}