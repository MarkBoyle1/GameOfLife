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

The program will immediately ask whether to load a saved seed generation:

<Insert Image>

### PreLoaded Selection

If the user selects "y" they will be presented with a list of seeds to choose from. 

Once a number is selected the game will play out the seed.

<Insert Image>


### Manual Selection

If the user selects "n" they will be asked to enter the grid width, grid height, and the location of the living cells for the seed generation.

<Insert Image>

To select the location of living cells an empty grid will appear with a cursor.

Move the cursor around using the keys indicated in the on-screen instructions.

Select and deselect cells until the desired pattern is created. Press the key for 'Finish selecting' once complete.

<Insert Image>


## Ways the Game Ends

- If an infinite loop is detected.
- If the game reaches the generation limit (default = 100)
- If there are no more living cells.
- If there is no change between generations.

## Class Diagram 

<Insert Diagram>



