using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class DatabaseSito
    {
        //crea app per vendere cellulari
        //crea login
        //3 coppie user e password
        //con authentication filter vedere se è autenticato o meno
        //visualizzare elenco (lato client o MVC) e mostrare elenco in pagina web
        //pulsante COMPRA 
        //compra modello e in automatico dopo che compri
        //ti porta alla pagine di logout per fare il log out -> pulsante gestito da javascript
        //sistema il css in modo che sia fruibile


        static List<Utente> utenti = new List<Utente>()
        {
            new Utente("manu", "a"),
            new Utente("rob", "a")
        };

        static List<Prodotto> prodotti = new List<Prodotto>();
        
        public static string Login(string u)
        {
            var utente = utenti.FirstOrDefault(l => l.Username == u);

            if (utente != null)
            {
                return "login effettuato";
            }
            else return "0";
        }

        public static List<Prodotto> GetProdotti()
        {
            var httpClient = new HttpClient();
            var webSite = new HttpRequestMessage(HttpMethod.Get, "https://gist.githubusercontent.com/hanse/4458506/raw/a702c19d07bd7693ee75efef18502c421b565949/phones.json");

            var resp = httpClient.Send(webSite);

            using(var reader = new StreamReader(resp.Content.ReadAsStream()))
            {
                var prod = reader.ReadToEnd();
                prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(prod);
            }

            return prodotti;
        }

        public static Prodotto GetProdotto(int id)
        {
            return prodotti.FirstOrDefault(p => p.Id == id)!;
        }

        
    }
}
