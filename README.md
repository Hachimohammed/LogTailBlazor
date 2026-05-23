# 📋 LogTail — Web Edition

> Visionneuse de logs en temps réel, migrée de WPF vers **Blazor WebAssembly**.
> Fonctionne directement dans le navigateur — aucune installation requise.

[![Deploy](https://github.com/TON_USERNAME/LogTailBlazor/actions/workflows/deploy.yml/badge.svg)](https://github.com/TON_USERNAME/LogTailBlazor/actions/workflows/deploy.yml)

## 🌐 Demo live

👉 **[https://TON_USERNAME.github.io/LogTailBlazor](https://TON_USERNAME.github.io/LogTailBlazor)**

## ✨ Fonctionnalités

- 📂 **Ouverture de fichier** — `.log`, `.txt`, `.csv` jusqu'à 100 MB
- 🎨 **Coloration syntaxique** — règles personnalisables par mot-clé (ERROR, WARN, INFO, DEBUG…)
- ⚡ **Filtres rapides** — boutons de filtre par niveau en un clic
- 🔍 **Filtre texte** — recherche en temps réel avec option case-sensitive
- 📊 **Colonnes auto** — détection automatique du séparateur (pipe, tab, virgule…)
- 💾 **Paramètres persistants** — sauvegardés dans localStorage
- ⬇ **Auto-scroll** — suit automatiquement les nouvelles lignes

## 🚀 Déploiement

### Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Développement local

```bash
git clone https://github.com/TON_USERNAME/LogTailBlazor
cd LogTailBlazor
dotnet run
# Ouvre http://localhost:5000
```

### GitHub Pages (automatique)

1. Fork ou push ce projet sur GitHub
2. Aller dans **Settings → Pages → Source : GitHub Actions**
3. Tout push sur `main` déclenche le déploiement automatiquement ✅

## 🔄 Migration depuis WPF

| WPF                     | Blazor WASM                    |
|-------------------------|--------------------------------|
| `FileSystemWatcher`     | `InputFile` + File API         |
| `ObservableCollection`  | `List<T>` + `StateHasChanged`  |
| `ListView` + `DataGrid` | `<Virtualize>` + table HTML    |
| JSON file settings      | `localStorage` via JSInterop   |
| XAML styles             | CSS                            |
| `Dispatcher.Invoke`     | `InvokeAsync` / direct render  |

## 📁 Structure

```
LogTailBlazor/
├── .github/workflows/deploy.yml   ← CI/CD GitHub Pages
├── Models/
│   ├── LogLine.cs                 ← Modèle avec colonnes parsées
│   ├── HighlightRule.cs
│   └── AppSettings.cs
├── Services/
│   ├── LogParserService.cs        ← Parse + coloration
│   └── SettingsService.cs         ← localStorage
├── Components/
│   └── RulesDialog.razor          ← Modal de gestion des règles
├── Pages/
│   └── Index.razor                ← Page principale
└── wwwroot/
    ├── css/app.css                ← Thème dark complet
    └── js/app.js                  ← Helpers JS
```
