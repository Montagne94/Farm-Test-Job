using Cinemachine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Grid
{
    private List<Cell> _cells = new List<Cell>();
    private Cell _currentCell;

    public Cell CurrentCell => _currentCell;

    public UnityAction<Cell> CellSelected;
    public UnityAction<Cell> CellUseded;
    public UnityAction<Plant> CellCollected;

    ~Grid()
    {
        foreach (Cell cell in _cells)
        {
            cell.Selected -= OnSelected;
        }
    }

    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
        cell.Selected += OnSelected;
        cell.Useded += OnUseded;
    }

    public void DisableDisplayCells()
    {
        foreach (Cell cell in _cells)
        {
            cell.CellDisplay.Hide();
        }
    }

    public void ChangeStateCells(bool state)
    {
        foreach(Cell cell in _cells)
        {
            cell.ChangeState(state);
        }
    }

    private void OnUseded(Cell cell)
    {
        CellUseded?.Invoke(cell);
    }

    private void OnSelected(Cell cell)
    {
        _currentCell = cell;
        DisableDisplayCells();
    }
}