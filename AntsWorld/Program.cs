﻿using AntsWorld;

const int worldWidth = 100;
const int worldHeight = 25;

var world = new World(worldWidth,worldHeight);
var projector = new WorldProjector(worldWidth, worldHeight);
var game = new ConsoleGame();

await game.RunUntilKeyPress(projector, world);