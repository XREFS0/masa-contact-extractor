# MASA Contact Extractor

A Windows desktop application for extracting emails and phone numbers from search engine results. Built with .NET Framework 4.8 and WinForms.

## Screenshot

![MASA Contact Extractor](docs/screenshot.png)

## Features

- **Multi-engine search** - Search via Google (Startpage proxy) and Bing/Yahoo
- **Email extraction** - Extracts email addresses from search results and web pages
- **Phone number extraction** - Extracts phone numbers with international format support
- **Website scanning** - Optionally crawl discovered websites for additional contacts
- **Social media filtering** - Target Facebook, Twitter, Instagram, LinkedIn specifically
- **Proxy support** - Use free proxy lists, custom proxy servers, or no proxy
- **Export** - Export results to CSV or copy to clipboard
- **Multi-threaded** - Configurable thread count for parallel processing

## Tech Stack

- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms with Krypton Ribbon/Toolkit
- **Browser Automation**: Selenium WebDriver (ChromeDriver)
- **HTML Parsing**: HtmlAgilityPack
- **Language**: C#

## Requirements

- Windows 10/11
- .NET Framework 4.8
- Google Chrome (latest version)
- ChromeDriver (matching Chrome version)

## Installation

1. Download the latest release from the releases page
2. Extract all files to a folder
3. Ensure ChromeDriver is available in your PATH or alongside the executable
4. Run `MASAContactExtractor.exe`

## Building from Source

```bash
# Clone the repository
git clone https://github.com/XREFS0/MASA.git
cd MASA

# Build with MSBuild
dotnet msbuild MASA.sln /p:Configuration=Release

# Or open MASA.sln in Visual Studio and build
```

## Project Structure

```
MASA/
├── Program.cs                    # Application entry point
├── MainForm.cs                   # Main UI and search orchestration
├── MainForm.Designer.cs          # Auto-generated form layout
├── SearchSettingsForm.cs         # Search configuration dialog
├── HTTPScraper.cs                # HTTP client and HTML parsing
├── ProxyServer.cs                # Proxy model and validation
├── Settings.cs                   # Application settings model
├── Data.cs                       # Data persistence model
├── Search/
│   ├── SearchProcess.cs          # Core search engine logic
│   ├── PageScraper.cs            # Website crawling
│   ├── Query.cs                  # Search query model
│   ├── DataType.cs               # Email/Phone enum
│   ├── SearchType.cs             # Google/Bing enum
│   └── WebClientEx.cs            # Extended WebClient
├── countries.lst                 # Country list data
├── country-codes.lst             # Country dialing codes
└── languages.lst                 # Language list data
```

## Configuration

Settings are stored in `%AppData%\MASA Contact Extractor\settings.cfg` as XML.

| Setting | Description | Default |
|---------|-------------|---------|
| SearchGoogle | Use Google via Startpage | true |
| SearchBing | Use Bing/Yahoo | false |
| DataEmails | Extract emails | true |
| DataPhones | Extract phone numbers | false |
| Threads | Parallel search threads | 2 |
| BingMaxPages | Max pages per search | 5 |

## Usage

1. Launch the application
2. Click **Start New Search**
3. Enter keywords (one per line)
4. Configure search engine, data type, proxy settings
5. Click **START**
6. Results appear in real-time in the data grid
7. Export to CSV or copy to clipboard when done

## Security

See [SECURITY.md](SECURITY.md) for security policy and vulnerability reporting.

## License

Copyright (c) 2026 XREFS0. All rights reserved.
