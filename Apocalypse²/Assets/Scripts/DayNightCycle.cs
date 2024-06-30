using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float day_cycle = 20;

    // Update is called once per frame
    void Update()
    {
        rot.x = day_cycle * Time.deltaTime;
        transform.Rotate(rot, Space.World);

    }
}