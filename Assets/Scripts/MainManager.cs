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
        public Color TeamColor;
        public string MyName;
    }

    public void SaveColor()
    {
        string folder = Application.persistentDataPath; //"C:\\Users\\Administrator\\Desktop";
        string fileName = "saveData.json";
        string fullPath = Path.Combine(folder, fileName);
        
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        data.MyName = "Big";
        string j = JsonUtility.ToJson(data);
        Debug.Log(j);
        Debug.Log(fullPath);
        
        File.WriteAllText(fullPath, j);
        /*PlayerPrefs.SetFloat("TeamColor.r", TeamColor.r);
        PlayerPrefs.SetFloat("TeamColor.g", TeamColor.g);
        PlayerPrefs.SetFloat("TeamColor.b", TeamColor.b);
        PlayerPrefs.SetFloat("TeamColor.a", TeamColor.a);*/
    }

    public void LoadColor()
    {
        string folder = Application.persistentDataPath; //"C:\\Users\\Administrator\\Desktop";
        string fileName = "saveData.json";
        string fullPath = Path.Combine(folder, fileName);
        if (File.Exists(fullPath))
        {
            string j = File.ReadAllText(fullPath);
            var data = JsonUtility.FromJson<SaveData>(j);
            TeamColor = data.TeamColor;
            
        }
        //string j = PlayerPrefs.GetString("saveData");
        
        /*TeamColor.r = PlayerPrefs.GetFloat("TeamColor.r");
        TeamColor.g = PlayerPrefs.GetFloat("TeamColor.g");
        TeamColor.b = PlayerPrefs.GetFloat("TeamColor.b");
        TeamColor.a = PlayerPrefs.GetFloat("TeamColor.a");*/
    }
}
