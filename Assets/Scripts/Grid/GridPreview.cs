using UnityEngine;

[ExecuteInEditMode]
public class GridPreview : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private GridGenerator _gridGenerator;

    private void OnRenderObject()
    {
        _material.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        Vector3 center = new Vector3(_gridGenerator.Width / 2f, 0, _gridGenerator.Height / 2f) * _gridGenerator.Spacing;

        GL.Begin(GL.LINES);
        for (int y = 0; y <= _gridGenerator.Height; y++)
        {
            Vector3 start = new Vector3(0, 0, y * _gridGenerator.Spacing) - center;
            Vector3 end = new Vector3(_gridGenerator.Width * _gridGenerator.Spacing, 0, y * _gridGenerator.Spacing) - center;
            GL.Vertex(start);
            GL.Vertex(end);
        }
        GL.End();

        GL.Begin(GL.LINES);
        for (int x = 0; x <= _gridGenerator.Width; x++)
        {
            Vector3 start = new Vector3(x * _gridGenerator.Spacing, 0, 0) - center;
            Vector3 end = new Vector3(x * _gridGenerator.Spacing, 0, _gridGenerator.Height * _gridGenerator.Spacing) - center;
            GL.Vertex(start);
            GL.Vertex(end);
        }
        GL.End();

        GL.PopMatrix();
    }
}