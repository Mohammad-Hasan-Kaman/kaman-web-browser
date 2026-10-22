# 🌐 Kaman Web Browser

> A lightweight, multi-tabbed desktop web browser built with C# and WinForms, powered by the Microsoft Edge WebView2 engine (Chromium). Supports tab management, smart search/navigation, and a clean user interface.

[![C#](https://img.shields.io/badge/C%23-4.8-blue.svg?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-Framework%204.8-green.svg?logo=dotnet)](https://dotnet.microsoft.com/)
[![Release](https://img.shields.io/github/v/release/Mohammad-Hasan-Kaman/kaman-web-browser?color=blue)](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/releases)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 🚀 Purpose & Target Audience

This project is designed for **"Lightweight local browsing with tab support"**:

| Audience | Usage Method |
|----------|--------------|
| **End Users** | Run the compiled `.exe` file for a simple, tabbed browsing experience. |
| **Developers** | Study the source code to understand WebView2 integration and WinForms UI logic. |

---

## ✨ Key Features

- 🌐 **Multi-Tab Support:**
  - Open, switch, and close multiple tabs seamlessly.
  - Dynamic tab titles that update automatically with page content.
- 🔍 **Smart Navigation & Search:**
  - **Auto-Detect:** Type a URL (e.g., `google.com`) or a search query.
  - **Smart Routing:** Automatically adds `https://` if missing and searches on Google if no URL is detected.
- 🔄 **Full Navigation Controls:**
  - **Back / Forward:** Traverse browsing history.
  - **Refresh / Stop:** Reload or halt page loading.
  - **New Tab / Close Tab:** Manage tabs with single clicks.
- 🎨 **Clean & Responsive UI:**
  - Built with **Windows Forms** for a native Windows look.
  - **Double-Buffered:** Prevents flicker and ensures smooth rendering.
  - **Transparent WebView2:** Properly handles background colors to avoid black borders.
- 🛡️ **Robust Error Handling:**
  - Graceful handling of navigation failures and engine initialization errors.
  - Optimized memory management (disposal of closed tabs to prevent leaks).

---

## 🛠 Tech Stack & Libraries

| Technology | Role |
|------------|------|
| **C# (.NET Framework 4.8, x64)** | Core programming language |
| **Windows Forms** | Desktop UI Framework |
| **Microsoft.Web.WebView2** | Embedded Chromium-based browser engine (Edge) |
| **System.Windows.Forms.TabControl** | Multi-tab management |
| **async/await** | Non-blocking UI operations for navigation |

---

## 📥 Installation & Setup

### 1. For End Users (Compiled Executable)

> **Prerequisite:** Windows 10/11 with **Microsoft Edge WebView2 Runtime** installed (usually pre-installed on modern Windows).

1.  Download the latest release from the [Releases](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/releases) page.
2.  Extract the archive into one folder. The release contains four files that must stay together:

    | File | Purpose |
    |------|---------|
    | `kaman-web-browser.exe` | The application |
    | `Microsoft.Web.WebView2.Core.dll` | WebView2 engine bindings |
    | `Microsoft.Web.WebView2.WinForms.dll` | WebView2 WinForms controls |
    | `WebView2Loader.dll` | Native loader (x64) |

3.  Run `kaman-web-browser.exe`.
4.  Type a URL or search query in the address bar and press **Enter**!

> Keeping the four files in the same folder is required — the WebView2 managed
> assemblies and the native loader are resolved next to the executable.

### 2. For Developers (Source Code)

```bash
# Clone the repository
git clone https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser.git
cd kaman-web-browser

# Open in Visual Studio
# Open "Web browser.sln"
# Right-click Solution -> "Restore NuGet Packages" (installs WebView2)
# Press F5 to run
```

---

## 📝 How to Use

1.  **Launch the App:** Run the executable.
2.  **Navigate:** Type a URL (e.g., `github.com`) or a search term in the top bar.
3.  **Open New Tab:** Click the **New Tab** button or use the shortcut.
4.  **Close Tab:** Click the **Close Tab** button (keeps at least one tab open).
5.  **Navigate History:** Use **Back** and **Forward** buttons to browse history.

---

## 📂 Project Structure

```
kaman-web-browser/
├── Form1.cs               # Main logic: tab management, navigation, event handling
├── Form1.Designer.cs      # UI layout (WinForms controls)
├── Form1.resx             # Embedded resources (icons, images)
├── Program.cs             # Entry point
├── Properties/            # Assembly info, resources and settings
├── Web browser.csproj     # Project file (.NET Framework 4.8, x64)
├── Web browser.sln        # Visual Studio solution
├── packages.config        # NuGet manifest (Microsoft.Web.WebView2)
├── App.config             # Application configuration
├── LICENSE                # MIT License
└── README.md              # This file
```

---

## 🤝 Contributing

Found a bug or have a suggestion? Please open an [Issue](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/issues).
Contributions are welcome!

---

## ⭐ Support

If you find this tool useful, please give it a **star**! ⭐

[![Stars](https://img.shields.io/github/stars/Mohammad-Hasan-Kaman/kaman-web-browser?style=for-the-badge&logo=github&color=blue)](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/stargazers)

---
*Maintained by Mohammad Hasan Kaman | Last updated: October 2026*

> **Disclaimer:** This is a lightweight browser client built for educational purposes. It relies on the Microsoft Edge WebView2 engine. For full browsing features, ensure the WebView2 Runtime is installed.
