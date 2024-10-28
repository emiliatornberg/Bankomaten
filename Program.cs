using System;

class Program
{
    static void Main(string[] args)
    {
        // Skapa en array för att hålla koll på saldon för 10 konton
        decimal[] konton = new decimal[10];

        // Starta meny-loopen
        bool körProgram = true;
        while (körProgram)
        {
            // Visa menyn för användaren
            Console.WriteLine("\nBankmeny:");
            Console.WriteLine("1. Sätt in pengar");
            Console.WriteLine("2. Ta ut pengar");
            Console.WriteLine("3. Visa saldo");
            Console.WriteLine("4. Visa alla konton");
            Console.WriteLine("5. Avsluta");
            Console.Write("Välj ett alternativ: ");

            // Läs in användarens val
            string val = Console.ReadLine();

            // Hantera användarens val
            switch (val)
            {
                case "1":
                    // Sätt in pengar
                    SättIn(konton);
                    break;
                case "2":
                    // Ta ut pengar
                    TaUt(konton);
                    break;
                case "3":
                    // Visa saldo för ett konto
                    VisaSaldo(konton);
                    break;
                case "4":
                    // Visa alla konton
                    VisaAllaSaldon(konton);
                    break;
                case "5":
                    // Avsluta programmet
                    körProgram = false;
                    Console.WriteLine("Programmet avslutas.");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    // Funktion för att sätta in pengar på ett konto
    static void SättIn(decimal[] konton)
    {
        Console.Write("Ange kontonummer (1-10): ");
        int kontonummer = int.Parse(Console.ReadLine()) - 1;
        if (kontonummer < 0 || kontonummer >= konton.Length)
        {
            Console.WriteLine("Ogiltigt kontonummer.");
            return;
        }

        Console.Write("Ange belopp att sätta in: ");
        decimal belopp = decimal.Parse(Console.ReadLine());
        if (belopp < 0)
        {
            Console.WriteLine("Insättningsbelopp kan inte vara negativt.");
            return;
        }

        konton[kontonummer] += belopp;
        Console.WriteLine($"Insättning lyckades! Nytt saldo för konto {kontonummer + 1}: {konton[kontonummer]:C}");
    }

    // Funktion för att ta ut pengar från ett konto
    static void TaUt(decimal[] konton)
    {
        Console.Write("Ange kontonummer (1-10): ");
        int kontonummer = int.Parse(Console.ReadLine()) - 1;
        if (kontonummer < 0 || kontonummer >= konton.Length)
        {
            Console.WriteLine("Ogiltigt kontonummer.");
            return;
        }

        Console.Write("Ange belopp att ta ut: ");
        decimal belopp = decimal.Parse(Console.ReadLine());
        if (belopp < 0)
        {
            Console.WriteLine("Uttagsbelopp kan inte vara negativt.");
            return;
        }

        if (konton[kontonummer] < belopp)
        {
            Console.WriteLine("Otillräckligt saldo.");
            return;
        }

        konton[kontonummer] -= belopp;
        Console.WriteLine($"Uttag lyckades! Nytt saldo för konto {kontonummer + 1}: {konton[kontonummer]:C}");
    }

    // Funktion för att visa saldot på ett specifikt konto
    static void VisaSaldo(decimal[] konton)
    {
        Console.Write("Ange kontonummer (1-10): ");
        int kontonummer = int.Parse(Console.ReadLine()) - 1;
        if (kontonummer < 0 || kontonummer >= konton.Length)
        {
            Console.WriteLine("Ogiltigt kontonummer.");
            return;
        }

        Console.WriteLine($"Saldo för konto {kontonummer + 1}: {konton[kontonummer]:C}");
    }

    // Funktion för att visa saldot för alla konton
    static void VisaAllaSaldon(decimal[] konton)
    {
        Console.WriteLine("Saldon för alla konton:");
        for (int i = 0; i < konton.Length; i++)
        {
            Console.WriteLine($"Konto {i + 1}: {konton[i]:C}");
        }
    }
}