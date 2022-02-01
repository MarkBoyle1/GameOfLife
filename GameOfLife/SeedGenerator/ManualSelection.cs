using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Exceptions;
using GameOfLife.Input;
using GameOfLife.Output;

namespace GameOfLife.SeedGenerator
{
    public class ManualSelection : ISeedGenerator
    {
        private readonly IUserInput _input;
        private readonly IOutput _output;
        public ManualSelection(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        
        public int GetGridWidth()
        {
            _output.DisplayMessage(OutputMessages.EnterGridWidth);
            return GetPositiveNumber();
        }
        
        public int GetGridHeight()
        {
            _output.DisplayMessage(OutputMessages.EnterGridHeight);
            return GetPositiveNumber();
        }

        private int GetPositiveNumber()
        {
            string userResponse = _input.GetUserInput();

            while (!int.TryParse(userResponse, out int number) || Convert.ToInt16(userResponse) < Constants.MinimumGridMeasurement)
            {
                _output.DisplayMessage(OutputMessages.InvalidGridMeasurement());
                userResponse = _input.GetUserInput();
            }

            return Convert.ToInt16(userResponse);
        }
        
        public List<CellPosition> GetPositionsOfLivingCells(int width, int height)
        {
            _output.DisplayMessage(OutputMessages.SelectLivingCellsForSeedGeneration);
            
            List<int> displayGrid =  Enumerable.Range(1, width * height).ToList();
            int activeCell = Constants.StartingCellPositionForManualSelection;
            List<int> selectedCells = new List<int>();
            bool userIsSelecting = true;
            
            _output.DisplaySelectionGrid(displayGrid, activeCell, selectedCells, width);

            while (userIsSelecting)
            {
                try
                {
                    _output.DisplayMessage(OutputMessages.ChooseSelectionGridAction());
                    activeCell = MoveActiveCell(activeCell, width, height);
                }
                catch (InputIsSelectDeselectException)
                {
                    if (selectedCells.Contains(activeCell))
                    {
                        selectedCells.Remove(activeCell);
                    }
                    else
                    {
                        selectedCells.Add(activeCell);
                    }
                }
                catch (FinishedSelectingException)
                {
                    userIsSelecting = false;
                }
                _output.DisplaySelectionGrid(displayGrid, activeCell, selectedCells, width);

            }

            List<CellPosition> livingCellPositions = new List<CellPosition>();
            selectedCells.ForEach(number => livingCellPositions.Add(new CellPosition(number)));

            return livingCellPositions;
        }
        
        private int MoveActiveCell(int activeCell, int width, int height)
        {
            string input = _input.GetUserInput();
            
            switch (input)
            {
                case Constants.Left:
                    activeCell = activeCell % width == 1 
                        ? activeCell + width - 1    //Wrapping around the grid
                        : activeCell - 1;
                    break;
                case Constants.Right:
                    activeCell = activeCell % width == 0 
                        ? activeCell - width - 1    //Wrapping around the grid
                        : activeCell + 1;
                    break;
                case Constants.Up:
                    activeCell = activeCell <= width 
                        ? activeCell + width * height - width   //Wrapping around the grid
                        : activeCell - width;
                    break;
                case Constants.Down:
                    activeCell = activeCell > (width * height) - width
                        ? activeCell - width * height - width   //Wrapping around the grid
                        : activeCell + width;
                    break;
                case Constants.SelectDeselect:
                    throw new InputIsSelectDeselectException();
                case Constants.FinishedSelecting:
                    throw new FinishedSelectingException();
            }

            return activeCell;
        }
    }
}