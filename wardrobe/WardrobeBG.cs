using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class WardrobeBG : MonoBehaviour
{
    VideoPlayer wardrobeBG;

    public void Initialize()
    {
        wardrobeBG = GetComponent<VideoPlayer>();       
    }
}
