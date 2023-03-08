namespace ConsoleTestApi;

class Program
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            // définit l'URL de votre API
            client.BaseAddress = new Uri("https://localhost:7240");

            // exécute la requête HTTP GET
            HttpResponseMessage response = await client.GetAsync("/Champion");

            // vérifie si la réponse est valide
            if (response.IsSuccessStatusCode)
            {
                // lit le contenu de la réponse
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Erreur : " + response.StatusCode);
            }
        }
    }
}
