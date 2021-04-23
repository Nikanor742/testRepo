#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Net;
class MyCustomBuilder :MonoBehaviour, IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        
        WebClient client = new WebClient();
        try
        {
            client.DownloadFile("http://upload.wikimedia.org/wikipedia/commons/5/51/Google.png", "image.png");
            Debug.Log("Image downloaded!");
        }
        catch
        {
            Debug.Log("Download Failed!");
        }
    }
}

#endif