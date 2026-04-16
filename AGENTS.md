# AGENTS.md

## What this repo is

A heavily modified RunUO Ultima Online server emulator written in C# (.NET Framework 4.0 / Mono). No package manager, no test framework, no linter, no CI.

## Do not change game code

The source files under `World/Source/` and `World/Info/Scripts/` are the source of truth for game behavior. **Do not modify them** unless explicitly asked. Use the code for discovery only.

## Directory map

| Path | Role |
|---|---|
| `World/Source/System/` | Core engine — compiled manually to `World.exe` |
| `World/Source/Scripts/` | Game scripts — compiled **at runtime** by the engine on startup |
| `World/Info/Scripts/` | Operator-layer overrides (`Settings.cs`, `Settings.override.cs`, `Merchant.cs`) |
| `World/Data/` | Binary/XML/map data; not source |
| `World/Saves/` | Live world state (binary serialization); not source |
| `wiki/` | Player-facing documentation (markdown); safe to read/write |

## Build

The engine binary (`World.exe` / `WorldLinux.exe`) must be compiled manually from `World/Source/System/*.cs` only:

**Linux (Mono):**
```sh
cd World/Source/Tools
bash compile-world-linux.sh
# output: World/WorldLinux.exe
```

**Windows (.NET Framework 4.0):**
```bat
cd World\Source\Tools
compile-world-win.bat
# output: World\World.exe
```

`World/Source/Scripts/` is **not** compiled by these scripts — the engine's `ScriptCompiler` compiles it at server startup automatically.

## Two-stage compilation — common gotcha

1. Manual: `compile-world-linux.sh` → produces engine binary.
2. Automatic: engine start → `ScriptCompiler` compiles `World/Source/Scripts/**/*.cs` + `World/Info/Scripts/**/*.cs` into in-memory assemblies.

Changes to scripts take effect on next server restart (no manual compile needed). Changes to `World/Source/System/` require rerunning the compile script.

## Settings / configuration

- `World/Info/Scripts/Settings.cs` — main config (`MySettings` class, ~800 lines, 12 categories).
- `World/Info/Scripts/Settings.override.cs` — per-instance overrides via `SettingOverrides.Initialize()`; modify this instead of `Settings.cs` to avoid touching tracked source.

## World build command

After certain config changes (e.g., `S_LineOfSight`, custom merchant flag), the world content (spawners, decorations, merchants) must be regenerated via the in-game/console command:
```
[buildworld
```
Implemented in `World/Source/Scripts/System/Misc/Build.cs`.

## Wiki work (`wiki/`)

See `wiki/AGENTS.md` for documentation goals and structure. Key rules:
- All docs in markdown, all files inside `wiki/`.
- Use source code for discovery; do not change any code.
- Game systems are in `World/Source/Scripts/Engines and Systems/` — 19 magic systems, 30+ quest types, full crafting/harvest/trade trees, skill implementations, etc.

## Entry point

`Server.Core.Main` in `World/Source/System/Main.cs`.
