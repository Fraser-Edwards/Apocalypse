using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWithMouse : MonoBehaviour
{
    public GameObject Object;

    private bool isActive = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isActive = true;
        }
        else if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.Alpha1))
            {
                isActive = false;
            }
        }

        if (!isActive) return;

        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Enable the target object
            Object.SetActive(true);
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0)) // 0 is the left mouse button
        {
            // Disable the target object
            Object.SetActive(false);
        }
    }
}
