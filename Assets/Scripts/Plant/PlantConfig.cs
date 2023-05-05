using UnityEngine;

[CreateAssetMenu(fileName = "New Plant ", menuName = "Plant ", order = 51)]
public class PlantConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _growthTime;
    [SerializeField] private float _startExperience;
    [SerializeField] private float _experienceCoefficient;

    public string Name => _name;
    public Sprite Icon => _icon;
    public float GrowthTime => _growthTime;
    public float StartExperience => _startExperience;
    public float ExperienceCoefficient => _experienceCoefficient;
}