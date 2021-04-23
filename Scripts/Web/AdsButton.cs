using UnityEngine;


public class AdsButton : MonoBehaviour
{
    [SerializeField] private string url;

    public void SetUrl(string _url)
    {
        url = _url;
    }
    private void OnMouseDown()
    {
        Application.OpenURL(url);
    }
}
