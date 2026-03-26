using System.Collections.Generic;
using System.Linq;

// ── Schritt 1: Array (Das feste Regal) ───────────────────────────────────────

string[] regalPlatze = { "Zylinderkopf", "Bremsscheibe", "Antriebswelle", "Lichtmaschine", "Nockenwelle" };

Array.Sort(regalPlatze);

Console.WriteLine("=== Schritt 1: Array – Das feste Regal ===");
foreach (string teil in regalPlatze)
{
    Console.WriteLine(teil);
}

// ── Schritt 2: List (Die dynamische Einlagerung) ──────────────────────────────

List<string> eingangskorb = new List<string>();
eingangskorb.Add("Schraube");
eingangskorb.Add("Mutter");
eingangskorb.Add("Bolzen");
eingangskorb.Add("Feder");

eingangskorb.RemoveAt(1); // entfernt "Mutter" (Index 1)

Console.WriteLine("\n=== Schritt 2: List – Dynamische Einlagerung ===");
if (eingangskorb.Contains("Schraube"))
    Console.WriteLine("'Schraube' ist noch in der Liste.");
else
    Console.WriteLine("'Schraube' wurde nicht gefunden.");

Console.WriteLine($"Verbleibende Teile: {eingangskorb.Count}");

// ── Schritt 3: Dictionary (Das Such-System) ───────────────────────────────────

Dictionary<int, string> lager = new Dictionary<int, string>
{
    { 101, "Motor" },
    { 102, "Getriebe" },
    { 103, "Reifen" }
};

Console.WriteLine("\n=== Schritt 3: Dictionary – Such-System ===");
FindArtikel(lager, 102);
FindArtikel(lager, 999);

// Zusatzaufgabe: alle Einträge ausgeben
Console.WriteLine("\n--- Alle Lagereinträge ---");
foreach (var eintrag in lager)
{
    Console.WriteLine($"ID: {eintrag.Key}, Teil: {eintrag.Value}");
}

static void FindArtikel(Dictionary<int, string> lager, int id)
{
    if (lager.TryGetValue(id, out string? name))
        Console.WriteLine($"Artikel gefunden – ID: {id}, Name: {name}");
    else
        Console.WriteLine($"Fehler: ID {id} ist unbekannt.");
}
