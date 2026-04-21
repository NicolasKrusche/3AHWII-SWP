# Aufgaben 2026-04-21

## 1. Free Tiers in Opencode

Erledigt in `opencode.json`.

Konfigurierte Optionen:

- OpenRouter Free Models
- Groq Free Tier
- Google AI Studio / Gemini
- Hugging Face Inference Providers
- NVIDIA API Catalog
- Mistral als Custom-Provider
- Ollama lokal als Custom-Provider

Dokumentation dazu: `2026-04-15_Inference/README.md`.

## 2. Was gut geht und Probleme

Gut:

- Opencode ist installiert und `opencode models --refresh` funktioniert.
- OpenRouter, Groq, Google, Hugging Face und NVIDIA werden von der CLI erkannt.
- Ein lokaler Ollama-Provider kann als OpenAI-kompatibler Endpoint vorbereitet werden.

Probleme:

- Es waren keine Provider-API-Keys als Umgebungsvariablen gesetzt.
- `mistral`, `cloudflare` und `ollama` wurden nicht als eingebaute Provider gefunden.
- `2025_Blazor` war lokal, in der Git-Historie und in einer schnellen GitHub-Suche nicht auffindbar. Deshalb wurde ein neues lauffähiges Blazor-Projekt im Repo erstellt.

## 3. Projekt 2025_Blazor

Das Projekt liegt jetzt unter `2025_Blazor/`.

Start:

```powershell
cd 2025_Blazor
dotnet run --no-launch-profile --urls http://localhost:5267
```

Dann im Browser öffnen:

```text
http://localhost:5267
```

## 4. Drei Lieblings-APIs aus public-apis

Quelle: https://github.com/public-apis/public-apis

### Open-Meteo

Warum: Wetterdaten ohne API-Key sind ideal für kleine Apps. Man kann damit Tagesplanung, Schulweg, Sport oder Events verbessern.

Idee: Eine Schulweg-Seite zeigt Regenrisiko, Temperatur und Wind für den Morgen.

### Open Library

Warum: Eine Buch-API passt gut zu Schule, Lernen und Projekten. Man kann Bücher suchen, Favoriten speichern und kleine Leselisten bauen.

Idee: Eine Klassen-Leseliste, bei der man Titel sucht und kurze Notizen dazuspeichert.

### REST Countries

Warum: Sehr einfache REST-API ohne Key, perfekt zum Üben von HTTP, JSON, Filtern und UI-Listen.

Idee: Ein Länder-Dashboard mit Flagge, Hauptstadt, Sprachen, Region und Suchfunktion.

## 5. Verbesserungs- und Änderungsvorschläge

### Für das Repo

- Eine zentrale `README.md` aktuell halten und neue Projekte sofort verlinken.
- Pro Projekt eine kurze Start-Anleitung mit `dotnet run`, `deno task ...` oder Test-Befehl ablegen.
- Alte Encoding-Probleme beheben, damit Umlaute nicht als kaputte Zeichen erscheinen.
- Für C#-Projekte eine gemeinsame Solution-Datei anlegen, wenn mehrere Projekte zusammen getestet werden sollen.

### Für public-apis

- API-Einträge nach "ohne API-Key" filterbar machen.
- Eine Spalte für "gut für Schulprojekte" oder "Beginner-friendly" wäre hilfreich.
- Beispiele für typische Fetch-Requests direkt neben beliebten APIs wären praktisch.

## 6. Traum-App bis Semesterende

Meine Traum-App: **Nexflow**.

Nexflow soll ein **Visual Agentic Operating System** werden. Die Idee: Man beschreibt eine Automation in normaler Sprache, Nexflow erzeugt daraus einen graphbasierten Agent-Workflow, und dieser Workflow kann anschließend visuell bearbeitet, geprüft und ausgeführt werden. Credentials und API-Keys bleiben dabei sicher serverseitig gespeichert.

Bis Ende Semester soll daraus ein sinnvoller MVP entstehen:

- Login mit Demo-Account
- Eingabefeld, in dem man eine Automation in natürlicher Sprache beschreibt
- automatische Erzeugung eines ersten Workflow-Graphs
- visueller Editor mit Nodes und Verbindungen
- Validierung vor dem Speichern und Ausführen
- einfache Run-Ansicht mit Status und Ergebnis
- sichere Verwaltung von Keys oder Connections
- mindestens ein bis zwei echte Beispiel-Workflows

Warum das realistisch ist: Das Repo hat schon eine klare Architektur mit Next.js, React Flow, Supabase, FastAPI, LangGraph und einem gemeinsamen Schema. Bis Semesterende muss nicht jedes Feature perfekt sein; wichtig ist ein stabiler Kern, der zeigt: Aus einer Idee wird ein validierter, editierbarer und ausführbarer Workflow.
