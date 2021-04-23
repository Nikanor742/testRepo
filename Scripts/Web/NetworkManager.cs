using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Net;
using UnityEngine.Video;
using System.IO;

public class NetworkManager : MonoBehaviour
{
    private PlayerList list;
    public List<VideoClip> videoList;
    public XPromoADObject XPromo;
    public Video video = new Video();

    public string SaveJSONToString()
    {
        return JsonUtility.ToJson(this);
    }
    IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }
    private void GetJSON()
    {
        StartCoroutine(GetRequest("https://drive.google.com/u/0/uc?id=1BrJNUCBB1n4EbCZBEU_0KWQdO1cnaWGt&export=download", (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }

            else
            {
                string jsonString = req.downloadHandler.text;
                list = JsonUtility.FromJson<PlayerList>(jsonString);//Список видео,для дальнейшей выборки
                int index = UnityEngine.Random.Range(0, 3);//Рандомный видос, для показа
                DownloadVideo(list.Items[index].link, list.Items[index].name);
            }
        }));
    }


    void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            AllDone();
        }
    }

    void AllDone()
    {
        string tmp = Application.persistentDataPath + $"/{video.name}.mp4";
        XPromo.LoadVideo(tmp);
    }

    private void DownloadVideo(string url, string name)
    {
        try
        {
            video.link = url;
            video.name = name;
            if (!File.Exists(Application.persistentDataPath + "/" + $"{name}.mp4"))
            {
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), Application.persistentDataPath + "/" + $"{name}.mp4");
            }
            else
            {
                AllDone();
            }
           
            //WebClient client = new WebClient();

            Debug.Log("VideoAds download success");
            //client.DownloadFile(url, Application.persistentDataPath + "/Video/" + name + ".mp4");

        }
        catch (Exception ex)
        {
            Debug.Log("VideoAds download failed: " + ex.Message);
        }

    }
    private void Awake()
    {
        XPromo = transform.parent.GetComponent<XPromoADObject>();
        GetJSON();
    }
}
[Serializable]
public class Video
{
    public string name;
    public string link;
}
public class PlayerList
{
    public List<Video> Items;
}

