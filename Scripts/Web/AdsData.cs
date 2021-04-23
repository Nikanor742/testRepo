using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdsData
{
    [Header("Project Name")]
    public string projectName;
    [Header("Project Url Link")]
    public string gameUrl;

    [Space, Tooltip("Video Urls")]
    public List<string> videoUrls;



    public void SetData(string _projectName, string _videoUrl, string _gameUrl)
    {
        projectName = _projectName;
       
        gameUrl = _gameUrl;
    }

    public string GetProjectName()
    {
        return projectName;
    }
    public string GetGameUrl()
    {
        return gameUrl;
    }
}
