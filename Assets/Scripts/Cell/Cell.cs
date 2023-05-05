using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

public class Cell : MonoBehaviour, ISelecteble
{
    [SerializeField] private Timer _timer;

    private CellDisplay _cellDisplay;
    private Plant _currentPlant;
    private bool _isUsed;
    private bool _isMature;
    private bool _isInteract = true;
    private float _currentExperience;
    [Inject] private Inventory _inventory;
    [Inject] private Experience _experience;

    public CellDisplay CellDisplay => _cellDisplay;
    public bool IsUsed => _isUsed;
    public bool IsInteract => _isInteract;

    public UnityAction<Cell> Selected;
    public UnityAction<Cell> Useded;
    public UnityAction<Cell> Planted;

    private void Awake()
    {
        _cellDisplay = FindObjectOfType<CellDisplay>(true);
    }

    private void OnEnable()
    {
        _timer.TimeEnded += OnTimeEnded;
    }

    private void OnDisable()
    {
        _timer.TimeEnded -= OnTimeEnded;
    }

    public void Initialize(Inventory inventory, Experience experience)
    {
        _inventory = inventory;
        _experience = experience;
    }

    public void SetPlant(Plant plant)
    {
        Useded?.Invoke(this);
        _currentPlant = plant;
        _cellDisplay.Hide();
        _isUsed = true;
    }

    public void PlantActivate()
    {
        _currentPlant = Instantiate(_currentPlant, transform.position, Quaternion.identity, transform);
        _timer.StartTime(_currentPlant.Config.GrowthTime, transform);
        Planted?.Invoke(this);
        StartCoroutine(ChangeExperience(_currentPlant.Config.StartExperience, _currentPlant.Config.ExperienceCoefficient, _currentPlant.Config.GrowthTime));
    }

    private void OnTimeEnded()
    {
        _isMature = true;
        _experience.AddExperience(_currentExperience);
        _currentExperience = 0;
    }

    public void Select()
    {
        if (_isInteract)
        {
            if (!EventSystem.current.IsPointerOverGameObject() && !_isUsed)
            {
                Selected?.Invoke(this);
                _cellDisplay.Show(transform);
            }

            if (_isMature && _currentPlant.TryGetComponent(out ICollecteble collecteble))
            {
                collecteble.Collect();
                _inventory.AddItem(_currentPlant);
                _currentPlant = null;
                _isUsed = false;
                _isMature = false;
            }
        }
    }

    public void ChangeState(bool state) => _isInteract = state;

    private IEnumerator ChangeExperience(float startExperience, float experienceCoefficient, float growthTime)
    {
        float elapsedTime = 0;

        while(elapsedTime <= growthTime)
        {
            elapsedTime += Time.deltaTime;
            _currentExperience = Mathf.RoundToInt(startExperience * Mathf.Exp(experienceCoefficient * elapsedTime));
            yield return null;
        }
    }
}