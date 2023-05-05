using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using System;

public class CameraSelecter : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _gridCamera;
    [SerializeField] private float _timeToDisable;

    private List<Cell> _cells = new List<Cell>();

    private void OnDisable()
    {
        foreach (Cell cell in _cells)
        {
            cell.Planted -= OnPlanted;
        }
    }

    public void AddCell(Cell cell)
    {
        _cells.Add(cell);
        cell.Planted += OnPlanted;
    }

    private void SetGrigCamera(Transform target)
    {
        _gridCamera.Follow = target;
        _gridCamera.enabled = true;

        Invoke(nameof(DisableCamera), _timeToDisable);
    }

    private void DisableCamera()
    {
        _gridCamera.enabled = false;
    }

    private void OnPlanted(Cell cell)
    {
        SetGrigCamera(cell.transform);
    }
}