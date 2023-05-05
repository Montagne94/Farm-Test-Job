using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if(hit.collider.TryGetComponent(out ISelecteble component))
                    {
                        component.Select();
                    }
                }
            }
        }
    }
}
