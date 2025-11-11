/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Model/Configuration class for email instances
 **/


namespace ItemDataLibrary.Configuration
{
  
    public class EmailConfiguration
    {
        public string SenderEmail { get; set; } = null!;
        public string AppPassword { get; set; } = null!;
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public bool EnableSsl { get; set; } = true;
    }
}