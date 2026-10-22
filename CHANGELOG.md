# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2026-10-22

### Fixed

- **The application now starts.** The `v1.0.0` release shipped the executable
  alone, without the WebView2 managed assemblies and the native loader, so it
  terminated immediately with a .NET unhandled exception (`0xE0434352`). This
  release ships the complete four-file bundle.
- Removed a hard-coded absolute `HintPath` to a commercial UI library, which
  made the project fail to build on any machine other than the author's.
- Removed a duplicate, broken legacy project whose resource files were missing,
  so the repository now has a single solution that actually compiles.
- Fixed the `git clone` URL in the README, which pointed at a repository name
  that does not exist.
- Documented the exact files to download and the requirement to keep them in the
  same folder.

### Removed

- The `v1.0.0` release and its tag, which could not start.
