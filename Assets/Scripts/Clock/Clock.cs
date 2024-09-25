using System;
using UnityEngine;


public class Clock : MonoBehaviour
{
    [SerializeField] private Material _material;

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    float interval = 0;

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0, 0, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0, 0, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0, 0, secondsToDegrees * (float)time.TotalSeconds);

        interval += Time.deltaTime;

        if(interval > 1)
        {
            interval = 0;
        }

        

        _material.color = new Color(interval, 1, Mathf.Repeat(Time.deltaTime, 1));
    }

}


