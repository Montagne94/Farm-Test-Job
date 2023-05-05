using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlantDisplay : MonoBehaviour
{
    [SerializeField] private Plant _plant;
    [SerializeField] private Image _image;

    private Button _selectButton;
    [Inject] private Grid _grid;

    private void Awake()
    {
        _selectButton = GetComponent<Button>();
    }

    private void OnEnable() => _selectButton.onClick.AddListener(SetPosition);

    private void OnDisable() => _selectButton.onClick.RemoveListener(SetPosition);

    private void Start() => _image.sprite = _plant.Config.Icon;

    private void SetPosition() => _grid.CurrentCell.SetPlant(_plant);
}