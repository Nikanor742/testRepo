using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class XPromoADObject : MonoBehaviour
{
    private XPromoVideo xPromoVideoPref;
    public Transform content;

    TMP_Text gameNameText;

    private void Awake()
    {
        // videoPlayer = GetComponentInChildren<VideoPlayer>();
        gameNameText = GetComponentInChildren<TMP_Text>();
    }

    public AdsData adsData;

    private void Start()
    {
        //LoadData();
    }
    public void LoadVideo(string video)
    {
        xPromoVideoPref = Resources.Load<XPromoVideo>("Video");
        XPromoVideo xpv = Instantiate(xPromoVideoPref, content);
        xpv.Init();
        RenderTexture renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        xpv.videoPlayer.url = video;
        xpv.ShowVideo(renderTexture);
        gameNameText.text = adsData.projectName;
    }
    private void LoadData()
    {
        xPromoVideoPref = Resources.Load<XPromoVideo>("Video");
        SetVideos();

        gameNameText.text = adsData.projectName;
    }

    private void SetVideos()
    {
        for (int i = 0; i < adsData.videoUrls.Count; i++)
        {
            XPromoVideo xpv = Instantiate<XPromoVideo>(xPromoVideoPref, content);
            xpv.Init();
            RenderTexture renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32); 
            xpv.videoPlayer.url = adsData.videoUrls[i];
            xpv.ShowVideo(renderTexture);
        }
    }

    public void OpenGameLink()
    {
        Application.OpenURL(adsData.gameUrl);
    }
}
