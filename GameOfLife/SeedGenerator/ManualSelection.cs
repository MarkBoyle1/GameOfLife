using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Exceptions;
using GameOfLife.Input;

namespace GameOfLife
{
    public class ManualSelection : ISeedGenerator
    {
        private IUserInput _input;
        private IOutput _output;
        public ManualSelection(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        public int MoveActiveCell(int activeCell, int width)
        {
            string input = _input.GetUserInput();
            
            switch (input)
            {
                case Constants.Left:
                    activeCell--;
                    break;
                case Constants.Right:
                    activeCell++;
                    break;
                case Constants.Up:
                    activeCell = activeCell - width;
                    break;
                case Constants.Down:
                    activeCell += width;
                    break;
                case Constants.SelectDeselect:
                    throw new InputIsSelectDeselectException();
                case Constants.FinishedSelecting:
                    throw new FinishedSelectingException();
            }

            return activeCell;
        }

        public List<CellPosition> GetPositionsOfLivingCells(int width, int height)
        {
            _output.DisplayMessage(OutputMessages.SelectLivingCellsForSeedGeneration);
            List<int> displayGrid =  Enumerable.Range(1, width * height).ToList();
            int activeCell = 1;
            List<int> selectedCells = new List<int>();
            bool userIsSelecting = true;
            _output.DisplaySelectionGrid(displayGrid, activeCell, selectedCells, width);

            while (userIsSelecting)
            {
                try
                {
                    _output.DisplayMessage(OutputMessages.ChooseSelectionGridAction());
                    activeCell = MoveActiveCell(activeCell, width);
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
            }

            List<CellPosition> livingCellPositions = new List<CellPosition>();
            selectedCells.ForEach(number => livingCellPositions.Add(new CellPosition(number)));

            return livingCellPositions;
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

            int number = 0;

            while (!int.TryParse(userResponse, out number))
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                userResponse = _input.GetUserInput();
            }

            while (Convert.ToInt16(userResponse) < Constants.MinimumGridMeasurement)
            {
                _output.DisplayMessage(OutputMessages.GridMeasurementTooLow());
                userResponse = _input.GetUserInput();
            }

            return Convert.ToInt16(userResponse);
        }
    }
}