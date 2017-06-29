# RRPG (WIP name)

## Content Structure
#### Overview

World -> Biomes -> Zones -> Interest Points

Saga -> Quests -> Objectives

NPC -> Interaction Meathods -> Objective Triggers



## Character Input

 - Race [Humans, Giants, Elves, Gnomes]
 - Class [Warior, Bard, Craftsman, Royalty]
 - Personality [Aggressive, Constructive, ??? ]

## Generators

### Quest
Quests are generated with a procedural grammar generator where key words define the triggers.
`(Example) Aggressive --> "Defeat" | Warior --> "Bear" == "Kill a bear"`

One quest should be made up of 4 or 5 smaller quests that build up to the final objective.

### Zones
Zones are generated with a tile based procedural generator.  The tiles are zones required first for the quest, then zones typical to the race, then zones to tie together the world.

### Geography
Geography is selected per zone from a set of acceptable geographical types, in addition to an over all biome that affects all zones.

### Map
The map adjusts geography or adds in structures to make the zones abe to be navagated. Buildings are also generated to suit the zone/biome.

### Nation
Lore and industry, as well as general personalities are generate here

### NPCs
The world gets populated with enough peopel to sustain a nation. NPC personalities should be generated only after being interacte with.

### Objectives
Objectives are the more concrete steps in a quest. `(example) talk to someone. do something. kill some thing...`
