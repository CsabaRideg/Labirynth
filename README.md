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



----- Magyarul:

Labirynth
**Látjátok feleim szemtevrel, mik vogymuk:
isa, ez világnak játéka vala,
melyet C# és WPF keze szerze.**

Prológus
Látjátok, miként ez kis mű, Labirynth neveztetik,
labirintusnak játéka, melyben az ember fia
járandó sok ösvényen, fordulón, rejtekhelyen,
s keresse az kijáratot, mielőtt az idő elenyésszék.

Ez játék íratott C# nyelven és WPF-vel,
s a pálya egyszerű szövegállományból olvastatik,
hogy ki-ki maga formálhassa az útvesztőt, miként akarja.
Az ember belép, bolyong, termeket jár be,
s csak az után menekedhetik, ha minden kötelességét teljesíté.

Az játékról
A Labirynth egy asztali labirintusjáték,
melyben a játékos box-drawing jelekből rajzolt pályán jár.
Keresnie kell minden termet, jelölve █ jellel,
s azután az kijárathoz kell jutnia, ha szabadságot kíván.

Az idő azonban szigorú úr:
harminc másodperc adatott neki,
s ha az idő elfogy, a játék véget ér.

Fő jeles tulajdonságok
🗺️ Térkép betöltése szövegből — a pálya .txt állományból olvastatik.

🧍 Játékos mozgatása — W, A, S, D billentyűkkel.

🏠 Termek bejárása — minden █ jellel jelölt terem meglátogatandó.

🚪 Kijárat logika — csak akkor nyílik meg az út, ha minden terem bejártatik.

💾 Mentés és visszatöltés — a játék állása elmenthető és ismét visszahozható.

⏱️ Visszaszámlálás — az idő fogy, mint az ember élete.

⏸️ Megállítás — a játék rövid időre megállítható.

🌍 Többnyelvűség — a feliratok lang.json állományból töltetnek.

📐 Reszponzív pályanézet — az ablak méretéhez a pálya igazodik.

Miképpen játszandó
Billentyű	Művelet
W	Fölfelé mész
A	Balra mégy
S	Lefelé mégy
D	Jobbra mégy
Az ember dolga
Nyomjad az „Pálya betöltése” gombot.

Járjad az útvesztőt a W A S D billentyűkkel.

Látogasd meg minden termet, mely █ jellel vagyon jelölve.

Ha minden terem megvolt, keresd meg az kijáratot.

Ha kijutsz, győzedelmet nyersz.

Az időről
Harminc másodperc adatott minden játékhoz.
Ha ez idő elmúlik, a játék elenyészik,
és a pálya újra kezdődik, ha nem vala elmentve az állás.

Mentés és visszatöltés
Az állás elmenthető, hogy a játékos ne veszítse el munkáját.

Az elmentett állomány tartalmazza:

a pálya jelen formáját,

a játékos helyét, P jellel,

a látogatott termeket, R{sor}:{oszlop} formában,

a hátralevő időt, T{másodperc} alakban.

Mentéshez: kattints az „Állás mentése” gombra.
Visszatöltéshez: kattints a „Pálya betöltése” gombra, s válaszd a mentett állományt.

Az pálya jeleiről
A pálya UTF-8 szövegállományban íratik,
s minden jel külön rendeltetésű.

Jel	Jelentés
╬	Keresztút, minden irány nyitva
═	Vízszintes folyosó
║	Függőleges folyosó
╦ ╩ ╣ ╠	Elágazások
╗ ╝ ╚ ╔	Sarkok
█	Terem, melyet meg kell látogatni
.	Üres hely, semmi
P	Játékos jelölése mentett állásban
Példa pálya
text
.║═══╗.
.║...║.
.╠═╦═╣.
.║.█.║.
.╚═╩═╝.
Példa mentés
text
P╬
R3:4
T18
Nyelv és beszéd
Minden felirat lang.json állományból olvastatik,
hogy a játék több nyelven szólhasson az emberhez.
Ha új nyelvet kívánsz adni, a JSON állományba új nyelvi ág teendő.

json
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
Technikai dolgok
Tulajdonság	Érték
Nyelv	C#
Keretrendszer	.NET / WPF
Felület	XAML, Canvas, Viewbox
Térkép	UTF-8 szövegállomány
Lokalizáció	lang.json
Mozgás	Billentyűzet, KeyDown
Időzítő	DispatcherTimer
Mentés	Szöveges állomány P, R, T sorokkal
Fájlok rendje
text
Labirynth/
├── Labirynth.sln
├── Labirynth/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── lang.json
│   └── maps/
│       ├── map1.txt
│       └── map2.txt
Hogyan indítandó
Másold le a repositoryt.

Nyisd meg a megoldást Visual Studio-ban.

Fordítsd és indítsd el a programot.

Tölts be egy pályát.

Járjad, míg győzelemre nem jutsz.

Szükséges dolgok
Windows operációs rendszer

Visual Studio 2022 vagy újabb

.NET 6.0 vagy újabb

Befejezés
Íme vala ez a kis mű,
mely játék és próbatétel egyszerre,
s melyben az ember az idővel viaskodik,
az útvesztőben pedig önmagával találkozik.

**Látjátok feleim, mik vogymuk:
kicsiny játék, de nagy próba.**
