using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false; // Hide the object

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
