using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterMove))]
public class Character : MonoBehaviour
{
    private CharacterMove _characterMove;
    private Cell _targetCell;

    public UnityAction PlantActivated;
    public UnityAction TargetSelected;

    public CharacterMove CharacterMove => _characterMove;

    private void Awake()
    {
        _characterMove = GetComponent<CharacterMove>();
    }

    public void SetCell(Cell cell)
    {
        _targetCell = cell;
        _characterMove.SetTarget(cell);
        TargetSelected?.Invoke();
    }

    private void TargetAchieved()
    {
        _targetCell.PlantActivate();
        PlantActivated?.Invoke();
    }
}