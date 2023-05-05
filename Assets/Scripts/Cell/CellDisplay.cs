using UnityEngine;

public class CellDisplay : MonoBehaviour
{
    private readonly float _offset = 100f;

    public void Show(Transform target)
    {
        gameObject.SetActive(true);

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        screenPosition = new Vector3(screenPosition.x, screenPosition.y + _offset, screenPosition.z);
        gameObject.SetActive(true);

        transform.position = screenPosition;
    }

    public void Hide() => gameObject.SetActive(false);
}