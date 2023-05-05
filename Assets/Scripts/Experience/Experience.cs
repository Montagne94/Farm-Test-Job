using UnityEngine.Events;

public class Experience
{
    private float _value;

    public UnityAction<int> ValueChanged;

    public void AddExperience(float value)
    {
        _value += value;
        ValueChanged?.Invoke((int)_value);
    }
}