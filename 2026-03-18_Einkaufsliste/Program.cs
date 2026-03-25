class Einkaufsliste
{
    private string[] artikel = new string[10];
    private int anzahl = 0;

    public int Anzahl => anzahl;

    public bool VersucheHinzufuegen(string artikel, out string meldung)
    {
        if (anzahl >= this.artikel.Length)
        {
            meldung = $"Fehler: Die Einkaufsliste ist voll. '{artikel}' konnte nicht hinzugefügt werden.";
            return false;
        }

        this.artikel[anzahl] = artikel;
        anzahl++;
        meldung = $"'{artikel}' wurde erfolgreich hinzugefügt. (Artikel {anzahl}/10)";
        return true;
    }

    public bool Enthaelt(string gesuchterArtikel)
    {
        bool gefunden = false;

        for (int i = 0; i < anzahl; i++)
        {
            if (artikel[i] == gesuchterArtikel)
            {
                gefunden = true;
                break;
            }
        }

        return gefunden;
    }

    public void GibKurzeNamenAus(int minLaenge)
    {
        Console.WriteLine($"Artikel mit weniger als {minLaenge} Zeichen:");

        for (int i = 0; i < anzahl; i++)
        {
            if (artikel[i].Length >= minLaenge)
            {
                continue;
            }

            Console.WriteLine($"  - {artikel[i]}");
        }
    }

    public static void VergleicheStrings()
    {
        string a = "Milch";
        string b = "Mil" + "ch";

        bool gleichheitOperator = (a == b);
        bool equalsMethode = a.Equals(b);

        Console.WriteLine($"String a: \"{a}\"");
        Console.WriteLine($"String b: \"{b}\"");
        Console.WriteLine($"a == b:       {gleichheitOperator}");
        Console.WriteLine($"a.Equals(b):  {equalsMethode}");
        Console.WriteLine($"Beide Vergleiche gleich: {gleichheitOperator == equalsMethode}");
    }
}

class Program
{
    static void Main()
    {
        Einkaufsliste liste = new Einkaufsliste();

        Console.WriteLine("=== Einkaufsliste ===\n");

        // VersucheHinzufuegen mit out-Parameter
        string[] einkäufe = { "Milch", "Brot", "Ei", "Butter", "Käse", "Joghurt", "Mehl", "Zucker", "Salz", "Pfeffer" };

        foreach (string item in einkäufe)
        {
            liste.VersucheHinzufuegen(item, out string meldung);
            Console.WriteLine(meldung);
        }

        // Liste voll – dieser Artikel passt nicht mehr rein
        liste.VersucheHinzufuegen("Olivenöl", out string fehlermeldung);
        Console.WriteLine(fehlermeldung);

        // Enthaelt mit break
        Console.WriteLine("\n=== Suche ===");
        string[] suchen = { "Brot", "Olivenöl" };
        foreach (string s in suchen)
        {
            Console.WriteLine($"Enthält '{s}': {liste.Enthaelt(s)}");
        }

        // GibKurzeNamenAus mit continue
        Console.WriteLine("\n=== Kurze Namen (< 5 Zeichen) ===");
        liste.GibKurzeNamenAus(5);

        // String-Vergleich Bonus
        Console.WriteLine("\n=== String-Vergleich ===");
        Einkaufsliste.VergleicheStrings();
    }
}
