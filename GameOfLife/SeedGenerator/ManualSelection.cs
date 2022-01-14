using System;
using System.Collections.Generic;
using GameOfLife.Exceptions;
using GameOfLife.Input;

namespace GameOfLife
{
    public class ManualSelection : ISeedGenerator
    {
        private IUserInput _input;
        public ManualSelection(IUserInput input)
        {
            _input = input;
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

        public List<CellPosition> GetPositionsOfLivingCells(int width)
        {
            int activeCell = 1;
            List<int> selectedCells = new List<int>();
            bool userIsSelecting = true;

            while (userIsSelecting)
            {
                try
                {
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
    }
}