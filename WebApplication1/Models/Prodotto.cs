namespace WebApplication1.Models
{
    public class Prodotto
    {
        static int cont = 1;
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }

        public Prodotto()
        {
            Id = cont++;
        }
    }
}
