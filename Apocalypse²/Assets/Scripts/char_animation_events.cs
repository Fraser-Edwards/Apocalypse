using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_animation_events : MonoBehaviour
{
    public bool Debug_Enabled = false;
    public string LeftFootRun = "fs_char_leftfootrun";
    public string RightFootRun = "fs_char_rightfootrun";
    public string LeftFootWalk = "fs_char_leftfootwalk";
    public string RightFootWalk = "fs_char_rightfootwalk";

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

 void fs_char_leftfoot_run()
    {
        if (Debug_Enabled) { Debug.Log("Left Foot Triggered"); }
AkSoundEngine.PostEvent(LeftFootRun, gameObject);
    }

    void fs_char_rightfoot_run()
    {
        if (Debug_Enabled) { Debug.Log("Right Foot Triggered"); }
        AkSoundEngine.PostEvent(RightFootRun, gameObject);
    }

    void fs_char_leftfoot_walk()
    {
        if (Debug_Enabled) { Debug.Log("Left Foot Triggered"); }
        AkSoundEngine.PostEvent(LeftFootWalk, gameObject);
    }

    void fs_char_rightfoot_walk()
    {
        if (Debug_Enabled) { Debug.Log("Right Foot Triggered"); }
        AkSoundEngine.PostEvent(RightFootWalk, gameObject);
    }
}
