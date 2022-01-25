# Conway's Game Of Life

## Rules

- Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any dead cell with exactly three live neighbours becomes a live cell.

## Creating the Seed Generation

There are two ways to create a seed generation:
- **Manual Selection:** Choose the width/height of the grid and the location of the living cells.
- **PreLoaded Selection:** Load the seed generation that was previously created and saved to a Json file. 

