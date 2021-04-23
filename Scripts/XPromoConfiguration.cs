using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class XPromoConfiguration : ScriptableObject
{
    #region Core
    private static XPromoConfiguration instance;
    public static XPromoConfiguration Instance
    {
        get { if (instance) return instance; else return instance = Resources.Load<XPromoConfiguration>("XPromo Configuration"); }
        set => instance = value;
    }


    [HideInInspector] public int _gameVersion = 1;
    [HideInInspector] public int _gameBuildVersion = 1;

    [SerializeField] private string _serverURL = string.Empty;



    public static string UserPath { get { return Application.persistentDataPath + "/User.json"; } }


    public void Reload() => instance = null;

    #endregion


    [Tooltip("HASH Code"), SerializeField] private string hashCode = "";
    public string HashCode { get => hashCode; set => hashCode = value; }
}