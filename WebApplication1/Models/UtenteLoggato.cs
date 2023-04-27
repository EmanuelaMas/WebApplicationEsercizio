namespace WebApplication1.Models
{
    public class UtenteLoggato : Utente
    {
        public bool ShowError { get; set; }

        public UtenteLoggato(bool showError)
        {
            ShowError = showError;
        }
    }
}
