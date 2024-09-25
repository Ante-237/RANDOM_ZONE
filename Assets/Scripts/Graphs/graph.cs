using UnityEngine;

public class graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;

    private void Start()
    {
        Vector3 position;
        position = Vector3.zero;
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;

        points = new Transform[resolution];

        for(int i = 0; i < resolution; i++)
        {
            Transform point = points[i] = Instantiate (pointPrefab);
            point.SetParent(transform, false);
            position.x = (i + 0.5f) * step - 1f;


            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;

        }
    }


    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * ((1/ ( position.x * position.x)) + time * 2));
            point.localPosition = position;
        }
    }


}