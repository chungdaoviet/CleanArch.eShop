namespace CleanArch.eShop.Infrastructure.Configurations
{
    public class MailSettings
    {
        public const string Section = nameof(MailSettings);
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
