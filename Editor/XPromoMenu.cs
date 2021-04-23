using UnityEngine;
using UnityEditor;
using System.Collections;


public class XPromoMenu : EditorWindow
{
    private string prefabName = "XPromoPref";

    [MenuItem("XPromo/Settings", false, 100)]
    public static void Settings()
    {
        EditorWindow.GetWindow(typeof(XPromoMenu));
    }
    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        if (GUI.Button(new Rect(10, 50, 100, 50), "Settings"))
        {
            Selection.activeObject = Resources.Load<XPromoConfiguration>("XPromo Configuration");
        }
        if (GUI.Button(new Rect(10, 110, 100, 50), "CreatePrefab"))
        {

            Object prefab = Resources.Load(prefabName);
            Instantiate(prefab);
            //string localPath = Resources.Load(prefabName + ".prefab");
            //localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
           
        }
    }
}
