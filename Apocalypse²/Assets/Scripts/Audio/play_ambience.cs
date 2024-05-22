using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_ambience : MonoBehaviour
{
    //Code form: https://alessandrofama.com/tutorials/wwise/unity/events#:~:text=Posting%20Wwise%20Events%20using%20the%20Wwise%20Picker%20in%20Unity,-Create%20a%20new&text=Ak%20Game%20Obj%20is%20automatically,to%20the%20Wwise%20sound%20engine.

    [SerializeField]
    private AK.Wwise.Event myEvent = null;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myEvent.Post(gameObject);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myEvent.Stop(this.gameObject, 500, AkCurveInterpolation.AkCurveInterpolation_Constant);
        }

    }



}
