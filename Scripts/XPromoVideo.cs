using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class XPromoVideo : MonoBehaviour
{
    Image image;
    private RawImage rawImage;

    [HideInInspector]
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        rawImage = GetComponent<RawImage>();
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        //TryGetComponent(out image);

    }

    public void ShowVideo(RenderTexture texture)
    {

        rawImage.texture = texture;
        videoPlayer.targetTexture = texture;

    }
}
