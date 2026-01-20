# Copilot / AI Agent Instructions for GGameker (TEngine)

This file gives concise, actionable guidance so an AI coding agent can be productive immediately in this Unity-based framework repository.

**Big Picture**
- **Main goal:** this repo is a Unity framework (TEngine) with a client-side architecture optimized for hotfixable games using HybridCLR, YooAsset, Luban and YooAsset-based resource strategies.
- **Key directories:** `UnityProject/` (Unity solution & Assets), `Tools/` (helpers: `FileServer`, `build-luban.bat`), `BuildCLI/` (CLI wrappers that call Unity), `Books/` (detailed docs), `Configs/` (game config templates).

**Architecture & important components**
- **Runtime modules:** look under `UnityProject/Assets/TEngine/Runtime/` and `UnityProject/Assets/GameScripts/` for modules such as ResourceModule, UIModule, ProcedureModule and GameEvent. These follow a modular, event-driven design (MVE).
- **Hotfix / assemblies:** hotfix entry lives in the HotFix assemblies (see `GameLogic` / `GameApp.cs` as the hotfix entry point referenced in README). Project assemblies are defined by `*.csproj` in `UnityProject/` (e.g. `GameLogic.csproj`, `GameProto.csproj`).
- **Config pipeline:** Luban is used for config generation: the repo provides `Tools/build-luban.bat` which runs `dotnet build` on Luban projects under `luban/`.

**Developer workflows & example commands**
- **Editor-driven run:** open Unity (recommended 2021.3.20f1 or newer) and use the `EditorMode`/`Launcher` in the Editor to run in-simulator mode (see `Books/1-快速开始.md`).
- **CLI Android build (Windows):** `BuildCLI/build_android.bat` calls Unity with `-executeMethod TEngine.ReleaseTools.AutomationBuildAndroid` — inspect that method if you need to modify automated build steps.
  - Example (Windows PowerShell):
    `BuildCLI\build_android.bat`
- **Luban (config tool):** run `Tools\build-luban.bat` which executes `dotnet build` to produce the Luban binary. Inspect `Configs/GameConfig/` for templates and generated outputs.
- **Local static file server:** `Tools/FileServer/` is a small Node.js static server. To run locally:
  - `cd Tools\FileServer` then `npm install` then `npm start` (or run `start.bat` which invokes the packaged `server` bin).

**Project-specific conventions and patterns**
- **Assembly separation:** project splits code between editor/runtime and hotfix assemblies. Look for `HotFix` and `GameLogic` folders for code meant to be built into hot-update DLLs.
- **Resource modes:** supports `EditorSimulateMode`, `OfflinePlayMode`, `HostPlayMode` (see resource module docs in `Books/3-1-资源模块.md`). Use these names when changing resource-loading logic.
- **Zero-GC event system:** events use lightweight integer/string IDs and are cleaned up per-UI lifecycle — search for `GameEvent` and `MVE` patterns when working with event code.
- **Build scripts are Windows-first:** many convenience scripts are `.bat`; parallel `.sh` exist. Prefer `.bat` on Windows unless the user requests POSIX changes.

**Cross-component integration points**
- **HybridCLR:** multiple Unity menu commands (see README) are used for hotfix workflows: `HybridCLR/Install...`, `HybridCLR/Define Symbols/Enable HybridCLR`, `HybridCLR/Generate/All`, and `HybridCLR/Build/BuildAssets And CopyTo AssemblyPath`. If automating, call these steps in Editor scripts or mirror them in CI via `-executeMethod` calls.
- **Asset bundling:** YooAsset builders run via Unity menus (`YooAsset/AssetBundle Builder`) and are used in automated pipelines.
- **Configuration generation:** Luban -> generated C#/data lives under `Configs/` and is consumed by `GameProto`/`GameLogic` assemblies. When changing the schema, run `Tools\build-luban.bat` and update generated artifacts.

**Where to look first (quick jump list)**
- `Books/1-快速开始.md` — quick start & editor guidance.
- `UnityProject/` — solution files and `*.csproj` to understand project boundaries.
- `BuildCLI/build_android.bat` — example of a headless Unity build invocation.
- `Tools/build-luban.bat` — how Luban is built/used.
- `Tools/FileServer/` — local static server used for hosting asset bundles.

If anything here is unclear or you want more detail in a specific area (CI automation, hotfix flow, or code paths for resource loading), tell me which area and I will expand the instructions or add examples/links to the exact files and methods.
