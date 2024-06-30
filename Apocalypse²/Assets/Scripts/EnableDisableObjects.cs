using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableObjects : MonoBehaviour
{
    public GameObject FPSObject;
    public GameObject TPSObect;
    public bool IsTPSView;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            IsTPSView =! IsTPSView;
        }

        if (IsTPSView)
        {
            TPSObect.SetActive(true);
            FPSObject.SetActive(false);
        }
        else
        {
            FPSObject.SetActive(true);
            TPSObect.SetActive(false);
        }
    }
}
