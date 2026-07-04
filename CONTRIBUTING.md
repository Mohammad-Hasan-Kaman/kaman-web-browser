# Contributing to Kaman Web Browser

Thank you for your interest in contributing to **Kaman Web Browser**! This is an open-source project designed to be a lightweight, multi-tabbed desktop browser. We welcome contributions from the community.

## 🤝 How to Contribute

### 1. Reporting Bugs
If you find a bug (e.g., navigation failure, tab crash, UI glitch), please open an [Issue](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/issues) and include:
- A clear title and description.
- Steps to reproduce the issue.
- Expected vs. actual behavior.
- Screenshots (if applicable).
- Your environment (OS, .NET Framework version, WebView2 version).

### 2. Suggesting Features
Have an idea for a new feature (e.g., bookmarks, history, themes)? Please open an [Issue](https://github.com/Mohammad-Hasan-Kaman/kaman-web-browser/issues) labeled `enhancement` and describe:
- The problem you're trying to solve.
- Your proposed solution.
- Why this feature is useful.

### 3. Submitting Code Changes
If you'd like to submit code changes:
1. **Fork** the repository.
2. Create a **new branch** from `main`:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes and ensure the code builds and runs.
4. Write **clear commit messages**:
   ```bash
   git commit -m "feat: Added history feature"
   ```
5. **Push** your branch:
   ```bash
   git push origin feature/your-feature-name
   ```
6. Open a **Pull Request (PR)** against `main`.

### 4. Code Style
- Follow C# coding conventions.
- Keep WinForms UI logic clean and modular.
- Ensure compatibility with the **Microsoft.Web.WebView2** engine.
- Add comments for complex logic, especially regarding WebView2 API usage.

## 🛠 Development Setup
- Install **Visual Studio** with .NET Desktop Development workload.
- Restore NuGet packages (installs `Microsoft.Web.WebView2`).
- Build and run the solution.

## 📝 License
By contributing, you agree that your contributions will be licensed under the **MIT License** of this project.

---

Thank you for helping make **Kaman Web Browser** better! 🚀