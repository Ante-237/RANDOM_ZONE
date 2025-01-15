
using UnityEngine;
using System.Collections.Generic;

public class TransformationGrid : MonoBehaviour
{
    public Transform prefab;

    public int gridRosolution = 10;

    Transform[] grid;
    List<Transformation> transformations;
    Matrix4x4 transformation;

    private void Awake()
    {
        grid = new Transform[gridRosolution * gridRosolution * gridRosolution];

        for(int i = 0, z = 0; z < gridRosolution; z++)
        {
            for(int y = 0; y < gridRosolution; y++)
            {
                for(int x = 0; x < gridRosolution; x++, i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }
        transformations = new List<Transformation>();
    }

    private void Update()
    {
        UpdateTransformation();
        for(int i = 0, z = 0; z < gridRosolution; z++)
        {
            for(int y = 0; y < gridRosolution; y++)
            {
                for(int x = 0;x < gridRosolution; x++, i++)
                {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }

    void UpdateTransformation()
    {
        GetComponents<Transformation>(transformations);
        if(transformations.Count > 0)
        {
            transformation = transformations[0].Matrix;
            for(int i = 1; i < transformations.Count; i++)
            {
                transformation = transformations[i].Matrix * transformation;
            }
        }
    }

    Vector3 TransformPoint(int x, int y, int z)
    {
        Vector3 coordinates = GetCoordinates(x, y, z);
        return transformation.MultiplyPoint(coordinates);
    }

    Transform CreateGridPoint (int x , int y, int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / gridRosolution,
            (float)y / gridRosolution,
            (float)z / gridRosolution
            );

        return point;
    }

    Vector3 GetCoordinates(int x, int y, int z)
    {
        return new Vector3(
            x - (gridRosolution - 1) * 0.5f,
            y - (gridRosolution - 1) * 0.5f,
            z - (gridRosolution - 1) * 0.5f
            );
    }
}
