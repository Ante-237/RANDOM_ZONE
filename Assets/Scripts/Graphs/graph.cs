using JetBrains.Annotations;
using UnityEngine;

public class graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    

    [SerializeField, Range(10, 100)]
    int resolution = 10;


    [SerializeField]
    FunctionLibrary.FunctionName function;

    Transform[] points;

    private void Start()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;

        points = new Transform[resolution * resolution];

        for(int i = 0; i < points.Length; i++)
        {

            Transform point = points[i] = Instantiate (pointPrefab);
            point.SetParent(transform, false);
            point.localScale = scale;

        }
    }

    private float accumulate = 0;

    private void Update()
    {
        float time = Time.time;

        if(time > accumulate + 5)
        {
            accumulate = time;
            
            if((int)function == 5)
            {
                function = 0;
            }
            else
            {
                function += 1;
            }
         
        }

        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution) {
                x = 0;
                z += 1;
                v = (z + 0.5f ) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = f(u, v, time);
        }
    }


}