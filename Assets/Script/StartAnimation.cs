using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartAnimation : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private double time;
    private double timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(PlayVideo());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
        }
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.loopPointReached += EndVideo;
        yield return null;
    }
    public void EndVideo(VideoPlayer videoPlayer)
    {
        Debug.Log("视频播放结束");
        Application.LoadLevel(1);
    }
}
