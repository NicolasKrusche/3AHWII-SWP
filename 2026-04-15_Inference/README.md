# Inference

Inference bedeutet: Ein Modell erzeugt aus gelernten Mustern eine neue Antwort, Vorhersage oder Entscheidung. Für unsere SWP-Aufgaben ist besonders wichtig, welche Dienste man kostenlos oder mit sehr kleinem Budget testen kann.

## Opencode-Konfiguration

Die Free-Tier-Provider aus dieser Recherche sind in der Repo-Datei `../opencode.json` eingetragen. Opencode liest Projekt- und globale Konfiguration zusammen, deshalb kann diese Datei direkt im Repo bleiben.

Nutzung:

```powershell
npm i -g opencode-ai
opencode models --refresh
opencode run "Sag kurz Hallo" -m openrouter/openai/gpt-oss-20b:free
```

Nötige API-Keys als Umgebungsvariablen:

```powershell
$env:OPENROUTER_API_KEY="..."
$env:GROQ_API_KEY="..."
$env:GOOGLE_API_KEY="..."
$env:HUGGINGFACE_API_KEY="..."
$env:NVIDIA_API_KEY="..."
$env:MISTRAL_API_KEY="..."
```

## Eingetragene Free-Tier-Optionen

| Provider | Opencode-Modelle / Provider | Was gut geht | Problem / Grenze |
| --- | --- | --- | --- |
| OpenRouter | `openrouter/openai/gpt-oss-20b:free`, `openrouter/meta-llama/llama-3.3-70b-instruct:free` | Viele Free-Modelle unter einem Key, guter Einstieg für Vergleiche. | Free-Modelle wechseln und haben Limits; man muss `opencode models openrouter --refresh` nutzen. |
| Groq | `groq/openai/gpt-oss-20b`, `groq/llama-3.1-8b-instant` | Sehr schnelle Antworten, gut für kleine Tools und Tests. | Free Tier hat Rate Limits; nicht jedes Modell ist für Coding gleich stark. |
| Google AI Studio | `google/gemini-2.5-flash`, `google/gemini-2.5-flash-lite` | Sehr guter Allrounder, besonders für Zusammenfassungen und UI-Ideen. | Key/Quota laufen über Google; Modellnamen können sich ändern. |
| Hugging Face | `huggingface/Qwen/Qwen3-Coder-Next`, `huggingface/moonshotai/Kimi-K2-Instruct` | Viele offene Modelle, spannend zum Ausprobieren. | Inference Providers haben je nach Anbieter unterschiedliche Limits und Wartezeiten. |
| NVIDIA | `nvidia/openai/gpt-oss-20b`, `nvidia/meta/llama-3.1-70b-instruct` | Gute Modellliste, auch für Open-Source-Modelle. | API-Key und Plattform-Login nötig; Free-Kontingent muss im Account geprüft werden. |
| Mistral | `mistral-free/mistral-small-latest`, `mistral-free/codestral-latest` | Kann über OpenAI-kompatiblen Endpoint in Opencode eingebunden werden. | Opencode hatte keinen eingebauten `mistral`-Provider; deshalb Custom-Provider. |
| Ollama lokal | `ollama-local/llama3.2:3b`, `ollama-local/qwen2.5-coder:7b` | Komplett lokal und ohne API-Kosten. | Nur lauffähig, wenn Ollama lokal installiert ist und das Modell gezogen wurde. |

## Was besonders gut geht

- `opencode models --refresh` findet aktuelle Modell-IDs sehr schnell.
- OpenRouter ist für den Unterricht praktisch, weil viele Free-Modelle mit einem Account testbar sind.
- Groq ist auffallend flott und eignet sich gut für kurze Prompts, Debugging-Ideen und Experimente.
- Lokale Modelle mit Ollama sind die beste Option, wenn man ohne Kostenlimit herumprobieren will.

## Probleme

- Keine API-Keys waren in der Umgebung gesetzt; echte Requests konnten deshalb nicht gegen die Provider getestet werden.
- `mistral`, `cloudflare` und `ollama` wurden von `opencode models <provider>` nicht als eingebaute Provider erkannt.
- Cloudflare Workers AI braucht einen Account-spezifischen Endpoint mit Account-ID. Ohne diese Daten ist eine sinnvolle Repo-Config zu riskant; deshalb ist Cloudflare hier dokumentiert, aber nicht aktiv eingetragen.
- Free Tiers ändern sich. Die Konfiguration ist ein Startpunkt, kein Dauervertrag.
