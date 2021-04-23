using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class TestVideo : MonoBehaviour, IPointerClickHandler
{
    [TextArea]
    public string url;

    public VideoPlayer videoPlayer;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShowVideo();
    }

    public void ShowVideo()
    {
        videoPlayer.url = url;
        try
        {
            StartCoroutine(Holder());
        }
        catch(Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    IEnumerator Holder()
    {
        float waitTime = 5;
        while (!videoPlayer.isPrepared)
        {
            yield return waitTime; break;
        }
        videoPlayer.Play();
    }


}
