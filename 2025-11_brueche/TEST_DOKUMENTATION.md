# Test-Doku für die Bruch-Klasse

## Überblick

In der Datei **BruchTest.cs** gibt ess **31 Tests**, die prüfen, ob die
Bruch‑Klasse korrekt funktioniert.

------------------------------------------------------------------------

# 1. Constructor mit String

###  Was wird getestet?

-   Richtige Formate funktionieren\
-   Automatisches Kürzen (`2/4 → 1/2`)\
-   Unechte Brüche werden gemischt (`0 3/2 → 1 1/2`)\
-   Ganze Zahlen werden korrekt angezeigt (`4 0/1 → 4`)

### **Beispiele**

-   `1 1/2` → **1 1/2**\
-   `4 0/1` → **4**\
-   `2 1/2` → **2 1/2**\
-   `0 3/2` → **1 1/2**\
-   `0 2/4` → **0 1/2**\
-   `1 6/8` → **1 3/4**

------------------------------------------------------------------------

# 2. Fehlerfälle (Exceptions)

### ❌ ArgumentException bei:

-   Leerer String `""`
-   `null`
-   Nenner = 0 (`1 1/0`)

### ❌ FormatException bei:

-   Nur Ganzzahl (`"1"`)
-   Buchstaben im Ganzzahlteil
-   Buchstaben in Zähler oder Nenner
-   Falsches Format (`"1 2-3"`)
-   Zu viele Teile (`"1 2 3 4/5"`)

------------------------------------------------------------------------

# 3. Constructor mit Integern

-   Funktioniert normal\
-   Nenner = 0 → Exception\
-   Automatisches Kürzen

------------------------------------------------------------------------

# 4. ToString()

-   Zähler 0 → nur Ganzzahl\
-   Mit Bruchanteil → gemischte Zahl\
-   Nur Bruch ohne ganze Zahl → `0 x/y`

------------------------------------------------------------------------

# 5. Addition

-   **1/2 + 1/4 = 3/4**\
-   **1 1/2 + 2 1/2 = 4**\
-   Unterschiedliche Nenner korrekt\
-   Addieren mit 0 funktioniert

------------------------------------------------------------------------

# Wie führt man die Tests aus?

## 🔹 In Visual Studio

**Test Explorer öffnen:** `Ctrl + E, T`\
Tests auswählen → starten

## 🔹 Über PowerShell

    dotnet test

Nur einen bestimmten Test ausführen:

    dotnet test --filter "BruchTest.Constructor_NennerIsZero_ThrowsArgumentException"

------------------------------------------------------------------------

# Test‑Zusammenfassung

  Kategorie                 Anzahl   Status
  ------------------------- -------- --------
  Gültige String‑Eingaben   6        ✔️
  Ungültige Eingaben        10       ✔️
  Int‑Constructor           3        ✔️
  toString                  3        ✔️
  Addition                  5        ✔️
  **Gesamt**                **27**   **✔️**

------------------------------------------------------------------------

# Welche Asserts werden benutzt?

-   **Assert.Equal(...)** → prüft Gleichheit\
-   **Assert.Throws`<T>`{=html}** → prüft erwarteten Fehler

------------------------------------------------------------------------

# Beispiel für einen eigenen Test

``` csharp
[Fact]
public void MyTest_Description_ExpectedResult()
{
    Bruch bruch = new Bruch("1 1/2");
    string result = bruch.ToString();
    Assert.Equal("1 1/2", result);
}
```

------------------------------------------------------------------------

# Dinge, die man noch testen könnte

-   Minus, Mal & Geteilt\
-   Negative Brüche\
-   Sehr große Zahlen\
-   Performance bei großen Nennern
