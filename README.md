# Conway's Game Of Life

The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970.

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input.

A seed generation is created on a grid with a pattern of living cells.

The next generation is created by applying a set of rules to the cells of the previous generation.

A sequence of generations will play out on the grid.


## Rules

- Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any dead cell with exactly three live neighbours becomes a live cell.

Any cell on the fringe of the grid will wrap around to the other side.

## Creating the Seed Generation

There are two ways to create a seed generation:
- **Manual Selection:** Choose the width/height of the grid and the location of the living cells.
- **PreLoaded Selection:** Load the seed generation that was previously created and saved to a Json file. 

The program will immediately ask whether to load a saved seed generation:

### PreLoaded Selection

If the user selects "y" they will be presented with a list of seeds to choose from. 

Once a number is selected the game will play out the seed.

<img width="420" alt="PreLoadedSelection" src="https://user-images.githubusercontent.com/88356611/151725164-45cb3688-fc47-46f4-8894-997a9031f4e5.png">

### Manual Selection

If the user selects "n" they will be asked to enter the grid width, grid height, and the location of the living cells for the seed generation.

To select the location of living cells an empty grid will appear with a cursor.

Move the cursor around using the keys indicated in the on-screen instructions.

Select and deselect cells until the desired pattern is created. Press the key for 'Finish selecting' once complete.

![ManualSelection](https://user-images.githubusercontent.com/88356611/151719605-02d50f1d-8747-4c01-b033-4a4244436a28.png)

## Ways the Game Ends

- If an infinite loop is detected.
- If the game reaches the generation limit (default = 100)
- If there are no more living cells.
- If there is no change between generations.

## Class Diagram

<img width="1650" alt="ClassDiagram" src="https://user-images.githubusercontent.com/88356611/151745740-0fcc106d-c54e-487c-b5f4-26985c02f71a.png">
