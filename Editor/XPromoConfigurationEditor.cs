#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(XPromoConfiguration))]
public class XPromoConfigurationEditor : Editor
{
    static string[] _dontIncludeMe = new string[] { "m_Script" };

    public override void OnInspectorGUI()
    {
        XPromoConfiguration target = (XPromoConfiguration)this.target;
        int version = target._gameVersion;
        int build = target._gameBuildVersion;

        EditorGUILayout.BeginHorizontal();
        {
            version = EditorGUILayout.IntField("Game Version", version);
            if (GUILayout.Button("+"))
            {
                version++;
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            build = EditorGUILayout.IntField("Build Version", build);
            if (GUILayout.Button("+"))
            {
                build++;
            }
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.Update();

        DrawPropertiesExcluding(serializedObject, _dontIncludeMe);

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            serializedObject.Update();

            serializedObject.FindProperty("_gameVersion").intValue = version;
            serializedObject.FindProperty("_gameBuildVersion").intValue = build;
            string versionString = (version / 1000) + "." + (version % 1000 / 100) + "." + (version % 100 < 10 ? "0" + (version % 100) : (version % 100).ToString());

            PlayerSettings.bundleVersion = versionString;

            PlayerSettings.Android.bundleVersionCode = build;
            PlayerSettings.iOS.buildNumber = build.ToString();



            serializedObject.ApplyModifiedProperties();

            target.Reload();
        }
    }
}
#endif