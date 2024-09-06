using AntsWorld;

var world = new World();
var projector = new WorldProjector(100, 25);
var game = new ConsoleGame();

await game.RunUntilKeyPress(projector, world);