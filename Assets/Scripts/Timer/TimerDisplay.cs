using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeUpdated += OnTimeUpdated;
    }

    private void OnDisable()
    {
        _timer.TimeUpdated -= OnTimeUpdated;
    }

    public void OnTimeUpdated(string value)
    {
        _value.text = value;
    }
}