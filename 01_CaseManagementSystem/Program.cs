using _01_CaseManagementSystem.Services;

var main = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("Ärendehanteringssystem");
    Console.WriteLine("");
    Console.WriteLine("1. Skapa nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett spesifikt ärende");
    Console.WriteLine("4. Kommentera eller ändra ett ärende");
    Console.WriteLine("5. Uppdatera Hyresgäst information för ett ärende");
    Console.WriteLine("6. Radera ett ärende");
    Console.WriteLine("");
    Console.Write("Välj ett av ovanstående alternativ: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await main.CreateNewErrorAsync();
            break;
        case "2":
            Console.Clear();
            await main.ListAllErrorsAsync();
            break;
        case "3":
            Console.Clear();
            await main.ListSpecficErrorAsync();
            break;
        case "4":
            Console.Clear();
            await main.CommentSpecficErrorAsync();
            break;
        case "5":
            Console.Clear();
            await main.UpdateSpecficErrorAsync();
            break;
        case "6":
            Console.Clear();
            await main.DeleteSpecficErrorAsync();
            break;
    }

    Console.WriteLine("\nTryck valfri tangent för att fortsätta.");
    Console.ReadKey();
}