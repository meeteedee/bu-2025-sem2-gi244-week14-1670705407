using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {

    }

    public void SaveColor()
    {
        PlayerPrefs.SetFloat("TeamColor.r", TeamColor.r);
        PlayerPrefs.SetFloat("TeamColor.g", TeamColor.g);
        PlayerPrefs.SetFloat("TeamColor.b", TeamColor.b);
        PlayerPrefs.SetFloat("TeamColor.a", TeamColor.a);
    }

    public void LoadColor()
    {
        TeamColor.r = PlayerPrefs.GetFloat("TeamColor.r");
        TeamColor.g = PlayerPrefs.GetFloat("TeamColor.g");
        TeamColor.b = PlayerPrefs.GetFloat("TeamColor.b");
        TeamColor.a = PlayerPrefs.GetFloat("TeamColor.a");
    }
}
