using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;
    [SerializeField]
    GameObject cameraused;
    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += EndReached;
    }
    private void OnDisable()
    {
        video.loopPointReached -= EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        cameraused.SetActive(true);
        gameObject.SetActive(false);
    }
}
