using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    [SerializeField] private protected PlantConfig PlantConfig;

    public PlantConfig Config => PlantConfig;
}