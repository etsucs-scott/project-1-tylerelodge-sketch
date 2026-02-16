# AdventureGame

A console-based 2D maze adventure game written in C#.

Build & Run Instructions

Using Visual Studio
1. Open the solution file.
2. Set `AdventureGame.Console` as the Startup Project if not already selected.
3. Build the solution (Build → Build Solution).
4. Press F5 or Ctrl+F5 to run.

Movement Controls

- W or Up Arrow → Move Up
- S or Down Arrow → Move Down
- A or Left Arrow → Move Left
- D or Right Arrow → Move Right

Invalid moves (walls or off-grid) will display an error message.

Display Format

Maze Symbols:

# = Wall
. = Empty Space
@ = Player
M = Monster
W = Weapon
P = Potion
E = Exit

After each move:
- The console clears
- The full maze redraws
- Player HP is displayed
- Any battle or item results appear above the maze


Game Rules

Player Stats
- Starts with 100 HP
- Maximum HP is 150
- Base damage is 10

Monsters
- Have 30–50 HP
- Deal 10 damage per attack
- Do not move

Weapons
- Added to inventory permanently
- No size limit
- Highest modifier applies to attacks

Potions
- Heal +20 HP
- Applied immediately
- Do not remain in inventory


Battle System

- Player always attacks first.
- Damage = 10 + highest weapon modifier.
- If monster survives, it counterattacks.
- Battle continues until one reaches 0 HP.
- No fleeing allowed.


Win / Lose Conditions

Win
Reach the Exit tile (E).

Lose
Player HP reaches 0.


Maze Generation

- Minimum size: 10x10
- Randomly generated walls, monsters, and items
- Exit is guaranteed reachable by carving a valid path before random expansion


UML Diagram

The UML diagram file includes:
- All required classes
- Interface implementation
- Inheritance
- Aggregation
- Composition
- Dependency
- Key fields and methods
