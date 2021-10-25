using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartAnimation : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
        }
    }

}
