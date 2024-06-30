using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArms : MonoBehaviour
{
    public GameObject Arms;
    public bool IsTPSView;


    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.V))
          {
              IsTPSView = !IsTPSView;
          }

          if (IsTPSView)
          {
              Arms.SetActive(true);
          }
          else
          {
              Arms.SetActive(false);
          }*/
        Arms.SetActive(false);
    }
}
