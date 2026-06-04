# 🏰 Labirynth

> *A maze of ink and iron, time and trial;*  
> *A little kingdom wrought in C#'s own fire.*

## Prologue

Attend, fair wanderer, and incline thine eye unto this curious work, this **Labirynth**, a game devised in **C# and WPF**, wherein a lone soul ventures through passages dark and chambers secret, seeking not merely movement, but meaning; not merely escape, but triumph.

Here are corridors drawn in stern black sigils, rooms marked as solemn stations of duty, and a clock most merciless that counts thy boldness by the second. Thus is the player summoned: to enter, to endure, to discover every hall required, and at the last to depart the maze in honor.

## Of the Game Itself

**Labirynth** is a desktop labyrinth game built with **C# and WPF (.NET)**, wherein the player traverses a maze fashioned from box-drawing characters, visits each required room, and claims the exit ere time itself doth fail.

The map is loaded from plain text, and so the maze may be reshaped at will by the author's hand. What is written may be played; what is played may be saved; what is saved may rise again upon another day.

## Noble Features

- 🗺️ **Map loading from text files** — The maze is read from `.txt` files composed of special labyrinth symbols.
- 🧍 **Player movement** — The wanderer moves with `W`, `A`, `S`, and `D`.
- 🏠 **Room visitation system** — Chambers marked with `█` must all be visited before escape is permitted.
- 🚪 **Exit logic** — The edge of the map becomes thy salvation only when thy duties within are complete.
- 💾 **Save and load** — Position, visited rooms, and remaining time may all be preserved and restored.
- ⏱️ **Countdown timer** — A fixed span of seconds governs each attempt.
- ⏸️ **Pause button** — Time may briefly stay its hand.
- 🌍 **Multi-language support** — User interface texts are governed through `lang.json`.
- 📐 **Responsive maze display** — The playfield adapts with the window and redraws to fit its allotted space.

## How One Plays

| Key | Office |
|-----|--------|
| `W` | Move upward |
| `A` | Move leftward |
| `S` | Move downward |
| `D` | Move rightward |

### The Player's Charge

1. Press **"Pálya betöltése"** to summon a map.
2. Traverse the labyrinth with the `W A S D` keys.
3. Seek out every room denoted by `█`.
4. Fulfil thy chamber-duty entire.
5. Find the exit upon the boundary and depart in victory.

### Of Time, That Cruel Steward

A countdown shadows every run. Should the allotted time expire ere thy task be finished, the maze is lost, the board is cleared, and thy venture ends in sorrow. Yet by saving thy state, thou mayst defy forgetfulness and return again.

## Of Saving and Returning

The game allows the present state to be written to file, that progress not perish.

A saved file contains:

- The present form of the map
- The player's current position, marked with `P`
- The rooms already visited, written as `R{row}:{col}`
- The time remaining, written as `T{seconds}`

To save thy progress: click **"Állás mentése"**  
To restore it: click **"Pálya betöltése"** and choose the saved file.

## Of Maps and Their Characters

Maps are stored as **UTF-8 plain text files**, and each symbol bears a precise office in the kingdom of the maze.

| Character | Meaning |
|-----------|---------|
| `╬` | Crossroads; all directions open |
| `═` | Horizontal corridor |
| `║` | Vertical corridor |
| `╦` `╩` `╣` `╠` | T-junctions |
| `╗` `╝` `╚` `╔` | Corners |
| `█` | Room that must be visited |
| `.` | Empty space or void |
| `P` | Player marker in a saved file, followed by the original underlying tile |

### Example Map

```txt
.╔═══╗.
.║...║.
.╠═╦═╣.
.║.█.║.
.╚═╩═╝.
```

### Example Save Data

```txt
P╬
R3:4
T18
```

## Of Tongues and Translation

All visible text within the game is drawn from `lang.json`, that the interface may speak in more than one language. To add another tongue, place a new language block within the JSON file.

```json
{
  "hu": {
    "Title": "Labirintus",
    "LoadMap": "Pálya betöltése"
  },
  "en": {
    "Title": "Labyrinth",
    "LoadMap": "Load Map"
  }
}
```

The player may then change the language through the selector within the program.

## Mechanicks and Materials

| Property | Value |
|----------|-------|
| Language | C# |
| Framework | .NET / WPF |
| Interface | XAML, Canvas, and layout-based drawing |
| Map source | UTF-8 text files |
| Localization | `lang.json` |
| Movement input | Keyboard via `KeyDown` |
| Timer | `DispatcherTimer` |
| Save format | Text-based state lines with `P`, `R`, and `T` markers |

## The Ordering of Files

```txt
Labirynth/
├── Labirynth.sln
├── Labirynth/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── lang.json
│   └── maps/
│       ├── map1.txt
│       └── map2.txt
```

## To Set It Running

1. **Clone the repository**
   ```bash
   git clone https://github.com/felhasznalonev/labirynth.git
   ```
2. **Open the solution** in Visual Studio.
3. **Build and run** the project.
4. **Load a map** with the proper button.
5. **Enter the maze** and prove thy worth.

## Requirements

- Windows operating system
- Visual Studio 2022 or later
- .NET 6.0 or later

## Epilogue

So stands this little work: part puzzle, part performance, part contest 'twixt the player and the clock. If fortune smiles and reason holds, the rooms shall all be known, the passage rightly read, and the exit taken as a king takes back his crown.

> *Exit, pursued by a timer.*



## ----- Magyarul:

# Labirynth

> *Látjátok feleim szemetekkel, mik vagyunk:*  
> *útvesztőben járók, idő által kergetettek.*

E kis mű egy **C# és WPF** alapokon épített labirintusjáték, melyben a játékos folyosók, sarkok, kereszteződések és termek között bolyong, mígnem minden kötelező helyet bejár, s végül megtalálja a kijáratot.

***

## Az játékról

A **Labirynth** egy asztali játék, mely szöveges térképekből építi fel a labirintust. A játékos a pályán `W`, `A`, `S`, `D` billentyűkkel mozog, termeket keres fel, s az idő szorításában próbálja elhagyni az útvesztőt.

A pálya egyszerű `.txt` állományból töltődik be, ezért könnyen szerkeszthető, bővíthető és új pályákkal gazdagítható.

***

## Fő tulajdonságok

- 🗺️ **Pályabetöltés szöveges fájlból**
- 🧍 **Mozgás billentyűzettel** (`W`, `A`, `S`, `D`)
- 🏠 **Termek látogatása** (`█` jelekkel jelölve)
- 🚪 **Kijárat csak a feladat teljesítése után**
- 💾 **Állás mentése és visszatöltése**
- ⏱️ **Visszaszámláló időzítő**
- ⏸️ **Játék megállítása**
- 🌍 **Többnyelvű felület `lang.json` segítségével**
- 📐 **Ablakmérethez igazodó pályamegjelenítés**

***

## Miképpen játszandó

| Billentyű | Jelentés |
|-----------|----------|
| `W` | Mozgás felfelé |
| `A` | Mozgás balra |
| `S` | Mozgás lefelé |
| `D` | Mozgás jobbra |

### A cél

1. Kattints a **Pálya betöltése** gombra.
2. Tölts be egy megfelelő `.txt` pályát.
3. Járd be a labirintust.
4. Látogasd meg az összes termet.
5. Ezután keresd meg a kijáratot, és hagyd el a pályát.

### Az időről

Minden játék meghatározott időkerettel indul. Ha az idő lejár, a futás véget ér, s a pálya elveszik, hacsak korábban el nem mentetett.

***

## Mentés és visszatöltés

A játék állása menthető, hogy a játékos később onnan folytathassa útját, ahol előzőleg megállt.

A mentett állomány tartalmazza:

- a pálya jelenlegi állapotát,
- a játékos helyét (`P`),
- a már bejárt termeket (`R{sor}:{oszlop}`),
- a hátralévő időt (`T{másodperc}`).

### Példa mentési sorokra

```txt
P╬
R3:4
T18
```

***

## A pálya jelei

A pálya UTF-8 kódolású szövegfájlban tárolódik. Az alábbi jelek használhatók:

| Jel | Jelentés |
|-----|----------|
| `╬` | Kereszteződés |
| `═` | Vízszintes folyosó |
| `║` | Függőleges folyosó |
| `╦` `╩` `╣` `╠` | Elágazások |
| `╗` `╝` `╚` `╔` | Sarkok |
| `█` | Terem |
| `.` | Üres hely |
| `P` | Játékos helye mentett állásban |

### Példa pálya

```txt
.╔═══╗.
.║...║.
.╠═╦═╣.
.║.█.║.
.╚═╩═╝.
```

***

## Nyelvek és `lang.json`

A kezelőfelület feliratai a `lang.json` fájlból töltődnek be, így a játék több nyelven is használható.

### Példa

```json
{
  "hu": {
    "Title": "Labirintus",
    "LoadMap": "Pálya betöltése"
  },
  "en": {
    "Title": "Labyrinth",
    "LoadMap": "Load Map"
  }
}
```

Új nyelv hozzáadásához elegendő egy új nyelvi blokkot felvenni a JSON állományba.

***

## Technikai adatok

| Tulajdonság | Érték |
|-------------|-------|
| Nyelv | C# |
| Keretrendszer | .NET / WPF |
| Felület | XAML |
| Pályaformátum | UTF-8 `.txt` |
| Lokalizáció | `lang.json` |
| Mozgás | `KeyDown` esemény |
| Időzítő | `DispatcherTimer` |
| Mentési formátum | `P`, `R`, `T` sorok |

***

## Projektstruktúra

```txt
Labirynth/
├── Labirynth.sln
├── Labirynth/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── lang.json
│   └── maps/
│       ├── map1.txt
│       └── map2.txt
```

***

## Indítás

1. Klónozd a repót.
2. Nyisd meg Visual Studio-ban.
3. Fordítsd le és indítsd el.
4. Tölts be egy pályát.
5. Játssz.

```bash
git clone https://github.com/felhasznalonev/labirynth.git
```

***

## Követelmények

- Windows
- Visual Studio 2022 vagy újabb
- .NET 6.0 vagy újabb

***

## Zárszó

> *Kicsiny játék ez, de nem kicsiny próbája az embernek.*  
> *Mert ki jól jár a labirintusban, az kijáratot lel;*  
> *ki pedig késik, azt elnyeli az idő.*
