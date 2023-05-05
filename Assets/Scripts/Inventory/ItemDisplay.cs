using TMPro;
using UnityEngine;
using Zenject;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;

    [Inject] private Inventory _inventory;

    private void OnEnable() => _inventory.CountChanged += OnCountChanged;

    private void OnDisable() => _inventory.CountChanged -= OnCountChanged;

    private void OnCountChanged(int value) => _count.text = value.ToString();
}