using UnityEngine;

public class CellRender : MonoBehaviour
{
    [SerializeField] private Material _selectedMaterial;

    private Material _defaultMaterial;
    private MeshRenderer _meshRenderer;
    private Cell _cell;

    private void Awake()
    {
        _cell = GetComponent<Cell>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _defaultMaterial = _meshRenderer.material;
    }

    private void OnMouseOver()
    {
        if (_cell.IsInteract)
            _meshRenderer.material = _selectedMaterial;
        else
            _meshRenderer.material = _defaultMaterial;
    }

    private void OnMouseExit()
    {
        _meshRenderer.material = _defaultMaterial;
    }
}