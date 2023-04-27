namespace WebApplication1.Models
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Utente(string u, string p)
        {
            Username = u;
            Password = p;
        }

        public Utente() { }
    }
}
