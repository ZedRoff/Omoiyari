using UnityEngine;

public class SmallTriangle2 : TangramShape
{
    void OnValidate()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(1, 1),
            new Vector3(2, 1),
            new Vector3(1, 2)
        };
        CreateShape(vertices);
    }
}

