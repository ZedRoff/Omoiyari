using UnityEngine;

public class BigTriangleRight : TangramShape
{
    void OnValidate()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(2, 0),
            new Vector3(2, 2),
            new Vector3(0, 2)
        };
        CreateShape(vertices);
    }
}

