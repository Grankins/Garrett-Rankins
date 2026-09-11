💾 Unity Save & Load System
A modular C# save/load system for Unity built to persist complex gameplay data across scenes and multiple save profiles.

![Save Slot UI](Save-Load-System/Screenshot 2026-09-11 062741.png?raw=true)

Built for a larger game project, the system handles everything from basic player data to inventory, machines, world state, progression, achievements, and more.

✨ Features
💾 Multiple save profiles
📄 JSON-based local save files
🔄 Automatic save/load object discovery
🌎 Cross-scene persistence
🗂️ Save profile management
🖥️ Save-slot UI
📦 Centralized game data
⚙️ Interface-based architecture

🏗️ Architecture
Gameplay Systems
       ↓
IDataPersistance
       ↓
DataPersistanceManager
       ↓
GameData
       ↓
FileDataHandler
       ↓
JSON Save File

Core Components
DataPersistanceManager
Coordinates saving, loading, profiles, and scene persistence.

FileDataHandler
Handles local file creation, reading, writing, deletion, and profile management.

GameData
Stores persistent gameplay state including player progression, inventory, resources, machines, world objects, contracts, and achievements.

IDataPersistance
Allows individual gameplay systems to participate in the save/load process without handling file operations themselves.

SaveSlot / SaveSlotsMenu
Handles the save profile UI and player profile selection.

📁 Structure
Save-Load-System/
├── DataPersistanceManager.cs
├── FileDataHandler.cs
├── GameData.cs
├── IDataPersistance.cs
├── SaveSlot.cs
├── SaveSlotsMenu.cs
└── README.md

🛠️ Built With
Unity
C#
Unity JsonUtility
.NET File I/O
Unity Scene Management
🎯 Goal
Create a scalable persistence system that allows new gameplay systems to save and load their own data without modifying the core save architecture.
