# 🏰 Labirintus — A WPF Labyrinth Game

> *"What a piece of work is a man! How noble in reason, how infinite in faculty!"*
> — and yet, he still gets lost in a maze.

***

## 📜 Foreword

Hark, brave soul, and lend thine eyes to this humble README, for within these walls of code doth lie a game most wondrous — a **labyrinth**, wrought in the fires of C# and WPF, where the player must navigate winding corridors, discover hidden chambers, and seek the blessed exit before the sands of time run dry.

***

## 🎮 What Is This Game?

**Labirintus** is a desktop labyrinth game built with **C# and WPF (.NET)**. The player navigates through a maze constructed of box-drawing characters, visits all required rooms, and then escapes through the exit — all before the countdown timer reaches zero.

The maze is loaded from a plain text file, making it fully customizable. Save your progress mid-game, return another day, and continue thy quest.

***

## ✨ Features

- 🗺️ **Text-based map loading** — Mazes are defined in `.txt` files using special box-drawing characters
- 🧍 **Player movement** — Navigate with `W`, `A`, `S`, `D` keys
- 🏠 **Room discovery** — Visit all marked rooms (`█`) before you may escape
- 🚪 **Dynamic exit detection** — The exit is only available once all rooms have been visited
- 💾 **Save & Load** — Save your current position, visited rooms, and remaining time; load it back at any moment
- ⏱️ **Countdown timer** — 30 seconds of glory; run out and the labyrinth claims thee
- ⏸️ **Pause functionality** — Stop time itself (briefly) with the pause button
- 🌍 **Multi-language support** — Switch between languages via a JSON language file (`lang.json`)
- 📐 **Responsive canvas** — The maze scales with the window size using WPF Viewbox

***

## 🕹️ How to Play

| Key | Action |
|-----|--------|
| `W` | Move Up |
| `A` | Move Left |
| `S` | Move Down |
| `D` | Move Right |

### The Goal

1. Load a map using the **"Pálya betöltése"** button
2. Navigate the labyrinth using the `W A S D` keys
3. Visit **all rooms** marked with `█` on the map
4. Once all rooms are visited, find the **exit** (any open edge of the map)
5. Confirm your escape — and glory shall be thine

### The Timer

Thou hast **30 seconds** per game. Should the clock expire before thy escape, the labyrinth swallows thee whole. Save thy progress if thou must depart.

***

## 💾 Save & Load

The game supports mid-game saving. The saved file contains:

- The current map state
- The player's position (marked with `P`)
- All visited rooms (marked with `R{row}:{col}` lines)
- Remaining time (marked with `T{seconds}`)

To save: click **"Állás mentése"**
To load: click **"Pálya betöltése"** and select a previously saved file

***

## 🗺️ Map Format

Maps are plain `.txt` files encoded in **UTF-8**. The following characters are used:

| Character | Meaning |
|-----------|---------|
| `╬` | Crossroads (all 4 directions) |
| `═` | Horizontal corridor |
| `║` | Vertical corridor |
| `╦` `╩` `╣` `╠` | T-junctions |
| `╗` `╝` `╚` `╔` | Corners |
| `█` | Room (must be visited) |
| `.` | Empty space (wall/void) |
| `P` | Player starting position (followed by the original character) |

### Example Map

```
.╔═══╗.
.║...║.
.╠═╦═╣.
.║.█.║.
.╚═╩═╝.
```

### Save File Extra Lines

```
P╬          ← Player is at a crossroads position
R3:4        ← Visited room at row 3, column 4
T18         ← 18 seconds remaining
```

***

## 🌍 Language Support

The game reads all UI text from `lang.json`. To add a new language, simply add a new entry to the JSON file:

```json
{
  "hu": {
    "Title": "Labirintus",
    "LoadMap": "Pálya betöltése",
    ...
  },
  "en": {
    "Title": "Labyrinth",
    "LoadMap": "Load Map",
    ...
  }
}
```

Switch languages in the application using the language selector dropdown.

***

## 🛠️ Technical Details

| Property | Value |
|----------|-------|
| Language | C# |
| Framework | .NET (WPF) |
| UI | XAML + Canvas + Viewbox |
| Map Format | UTF-8 plain text |
| Config | `lang.json` |
| Movement | Keyboard (`KeyDown` event) |
| Timer | `DispatcherTimer` |

***

## 📁 Project Structure

```
Labirynth/
├── Labirynth.sln
├── Labirynth/
│   ├── MainWindow.xaml         ← UI layout
│   ├── MainWindow.xaml.cs      ← Game logic
│   ├── lang.json               ← Language strings
│   └── maps/
│       ├── map1.txt            ← Example maps
│       └── map2.txt
```

***

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/felhasznalonev/labirynth.git
   ```

2. **Open in Visual Studio**
   Open `Labirynth.sln`

3. **Build & Run**
   Press `F5` or click **Start**

4. **Load a map**
   Click **"Pálya betöltése"** and select a `.txt` map file

5. **Play!**

***

## ⚙️ Requirements

- Visual Studio 2022 (or later)
- .NET 6.0 or higher
- Windows OS (WPF is Windows-only)

***

## 📜 License

*"All the world's a stage"* — and this code is freely given to it.
This project is open source. Do with it as thou wilt, but credit where credit is due.

***

> *"Though she be but little, she is fierce."*
> — So too is this labyrinth. Good luck.
