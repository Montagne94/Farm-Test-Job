using TMPro;
using UnityEngine;
using Zenject;

public class ExperienceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;


    [Inject] private Experience _experience;
    private int _currentValue;

    private void OnEnable() => _experience.ValueChanged += OnValueChanged;   

    private void OnDisable() => _experience.ValueChanged -= OnValueChanged;

    private void OnValueChanged(int value) => _value.text = value.ToString();
}