using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Farm : MonoBehaviour, ISelecteble
{
    [SerializeField] private Character _character;

    [Inject] private Grid _grid;

    private void OnEnable()
    {
        _grid.CellUseded += OnUseded;
        _character.TargetSelected += OnTargetSelected;
        _character.PlantActivated += OnPlantActivated;
    }

    private void OnDisable()
    {
        _grid.CellUseded -= OnUseded;
        _character.TargetSelected -= OnTargetSelected;
        _character.PlantActivated -= OnPlantActivated;
    }

    public void Select()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            _grid.DisableDisplayCells();
    }

    private void OnUseded(Cell cell)
    {
        _character.SetCell(cell);
    }

    private void OnTargetSelected()
    {
        _grid.DisableDisplayCells();
        _grid.ChangeStateCells(false);
    }

    private void OnPlantActivated()
    {
        _grid.ChangeStateCells(true);
    }
}