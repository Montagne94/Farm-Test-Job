using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class Inventory
{
    private List<Plant> _plants = new List<Plant>();

    public UnityAction<int> CountChanged;

    public void AddItem(Plant plant)
    {
        _plants.Add(plant);
        int count = _plants.Count(plant => plant is Carrot);
        CountChanged?.Invoke(count);
    }
}