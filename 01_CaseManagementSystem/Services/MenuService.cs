using _01_CaseManagementSystem.Models;

namespace _01_CaseManagementSystem.Services
{

    internal class MenuService
    {
        public async Task CreateNewErrorAsync()
        {
            var tenant = new Tenant();

            Console.WriteLine("Skapa ett nytt ärende: ");
            Console.Write("Förnamn: ");
            tenant.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            tenant.LastName = Console.ReadLine() ?? "";

            Console.Write("Epostadress: ");
            tenant.Email = Console.ReadLine() ?? "";

            Console.Write("Telefon nr: ");
            tenant.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            tenant.StreetName = Console.ReadLine() ?? "";

            Console.Write("Post nr: ");
            tenant.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            tenant.City = Console.ReadLine() ?? "";

            Console.Write("Namnge ärende: ");
            tenant.ErrorTitle = Console.ReadLine() ?? "";

            Console.Write("Beskriv ärende: ");
            tenant.Description = Console.ReadLine() ?? "";

            Console.WriteLine("Välj status: ");
            Console.WriteLine("1 = Ej påbörjad\n2 = Pågående\n3 = Avslutad: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                tenant.Status = "Ej påbörjad";
            }
            else if (input == "2")
            {
                tenant.Status = "Pågående";
            }
            else if (input == "3")
            {
                tenant.Status = "Avslutad";
            }
            Console.WriteLine("Ärende sparat");

            await ErrorService.SaveAsync(tenant);
        }

        public async Task ListAllErrorsAsync()
        {
            var tenants = await ErrorService.GetAllAsync();

            if (tenants.Any())
            {
                foreach (Tenant tenant in tenants)
                {
                    Console.WriteLine($"Hyresgäst-id: {tenant.Id}");
                    Console.WriteLine($"Namn : {tenant.FirstName} {tenant.LastName}");
                    Console.WriteLine($"Epostadress : {tenant.Email}");
                    Console.WriteLine($"Telefon nr : {tenant.PhoneNumber}");
                    Console.WriteLine($"Adress : {tenant.StreetName}, {tenant.PostalCode} {tenant.City}");
                    Console.WriteLine($"Ärende : {tenant.ErrorTitle}");
                    Console.WriteLine($"Beskrivning : {tenant.Description}");
                    Console.WriteLine($"Skapat : {tenant.CreatedAt}");
                    Console.WriteLine($"Status : {tenant.Status}");
                    Console.WriteLine("");
                    Console.WriteLine($"Komentar: {tenant.UpdateComment} \n{tenant.UpdatedAt}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga ärenden i databasen...");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecficErrorAsync()
        {
            Console.Write("Skriv epostadress för att hitta spesifikt ärende : ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var tenant = await ErrorService.GetAsync(email);

                if (tenant != null)
                {
                    Console.WriteLine($"Hyresgäst-id : {tenant.Id}");
                    Console.WriteLine($"Namn : {tenant.FirstName} {tenant.LastName}");
                    Console.WriteLine($"Epostadress : {tenant.Email}");
                    Console.WriteLine($"Telefon nr : {tenant.PhoneNumber}");
                    Console.WriteLine($"Adress : {tenant.StreetName}, {tenant.PostalCode} {tenant.City}");
                    Console.WriteLine($"Ärende : {tenant.ErrorTitle}");
                    Console.WriteLine($"Beskrivning : {tenant.Description} ");
                    Console.WriteLine($"Skapat : {tenant.CreatedAt}");
                    Console.WriteLine($"Status : {tenant.Status}");
                    Console.WriteLine("");
                    Console.WriteLine($"Komentar: {tenant.UpdateComment} \n{tenant.UpdatedAt}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen hyresgäst med {email} kunde hittas...");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen epostadress angiven");
            }
        }
        public async Task CommentSpecficErrorAsync()
        {
            Console.Write("Ange epostadress för ärändet du vill komentera på: ");
            Console.WriteLine("");

            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var tenant = await ErrorService.GetAsync(email);
                if (tenant != null)
                {
                    Console.WriteLine("Komentera på följande ärende. ");
                    Console.Write($"Komentar: ");

                    tenant.UpdateComment = Console.ReadLine() ?? "";

                    Console.WriteLine($"{tenant.UpdatedAt}");
                    Console.WriteLine("");
                    Console.WriteLine("Status uppatering :");
                    Console.WriteLine("1 = Ej påbörjad\n2 = Pågående\n3 = Avslutad: ");

                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        tenant.Status = "Ej påbörjad";
                    }
                    else if (input == "2")
                    {
                        tenant.Status = "Pågående";
                    }
                    else if (input == "3")
                    {
                        tenant.Status = "Avslutad";
                    }
                }
                await ErrorService.UpdateAsync(tenant);
                Console.WriteLine("Uppdaterat");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen epostadress angiven");
            }
        }

        public async Task UpdateSpecficErrorAsync()
        {
            Console.Write("Skriv in epostadressen på hyresgästen du vill uppdatera informationen på: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var tenant = await ErrorService.GetAsync(email);

                if (tenant != null)
                {
                    Console.Write("Förnamn: ");
                    tenant.FirstName = Console.ReadLine() ?? "";

                    Console.Write("Efternamn: ");
                    tenant.LastName = Console.ReadLine() ?? "";

                    Console.Write("Epostadress: ");
                    tenant.Email = Console.ReadLine() ?? "";

                    Console.Write("Telefon nr: ");
                    tenant.PhoneNumber = Console.ReadLine() ?? "";

                    Console.Write("Adress: ");
                    tenant.StreetName = Console.ReadLine() ?? "";

                    Console.Write("Post nr: ");
                    tenant.PostalCode = Console.ReadLine() ?? "";

                    Console.Write("Stad: ");
                    tenant.City = Console.ReadLine() ?? "";

                    Console.Write("Namnge ärende: ");
                    tenant.ErrorTitle = Console.ReadLine() ?? "";

                    Console.Write("Beskrivning av ärende: ");
                    tenant.Description = Console.ReadLine() ?? "";

                    await ErrorService.UpdateAsync(tenant);
                    Console.WriteLine("Uppdaterat");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen epostadress angiven");
            }
        }
        public async Task DeleteSpecficErrorAsync()
        {
            Console.Write("Skriv in epostadressen på hyresgästen du vill radera ärende på: ");
            var email = Console.ReadLine();
            Console.WriteLine("Vill du radera ärende för " + email + " ifrån listan? ");
            Console.Write("j = ja. n = nej.");
            var input = Console.ReadLine();

            if (input == "j")
            {
                await ErrorService.DeleteAsync(email);
                Console.WriteLine("Ärendet har blivit raderat...");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen epostadress angiven");
            }
        }
    }
}
