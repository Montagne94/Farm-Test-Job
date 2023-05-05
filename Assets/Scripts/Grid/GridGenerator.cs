using UnityEngine;
using Zenject;

[RequireComponent(typeof(GridPreview))]
public class GridGenerator : MonoBehaviour
{
    [SerializeField] private CameraSelecter _cameraSelecter;
    [SerializeField] private Cell _prefab;
    [SerializeField][Range(1, 8)] private int _width;
    [SerializeField][Range(1, 8)] private int _height;
    [SerializeField][Range(0f, 1.3f)] private float _spacing;
    [SerializeField] private SceneContext _sceneContext;

    private Vector3 _centerOffset;
    private GridPreview _gridPreview;
    private DiContainer _container;
    [Inject] private Grid _grid;

    public int Width => _width;
    public int Height => _height;
    public float Spacing => _spacing;

    private void Awake()
    {
        _gridPreview = GetComponent<GridPreview>();
    }

    private void Start()
    {
        _container = _sceneContext.Container;
        _gridPreview.enabled = false;
        float gridWidth = (_width - 1) * _spacing;
        float gridHeight = (_height - 1) * _spacing;

        _centerOffset = new Vector3(-gridWidth / 2f, 0f, -gridHeight / 2f);

        SpawnGrid(transform.position);
    }

    private void SpawnGrid(Vector3 parentCenter)
    {
        Vector3 gridPoint = parentCenter + _centerOffset;

        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                Vector3 position = new Vector3(x * _spacing, 0f, z * _spacing) + gridPoint;
                Cell cell = Instantiate(_prefab, position, _prefab.transform.rotation, transform);
                cell.Initialize(_container.Resolve<Inventory>(), _container.Resolve<Experience>());
                _grid.AddCell(cell);
                _cameraSelecter.AddCell(cell);
            }
        }
    }
}