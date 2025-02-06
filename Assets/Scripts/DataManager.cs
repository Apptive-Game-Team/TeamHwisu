using UnityEngine;
using System.IO;

public class PlayerData
{
    public int coin;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData nowPlayer;
    private PlayerData startingPlayer;

    private string path;
    private string filename = "save.json";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/";

        // 기본 플레이어 데이터 초기화
        startingPlayer = new PlayerData()
        {
            coin = 9999
        };

        LoadData();
    }

    public void SaveData()
    {
        try
        {
            string data = JsonUtility.ToJson(nowPlayer, true); // JSON pretty print
            File.WriteAllText(path + filename, data);
            Debug.Log("데이터 저장 완료: " + path + filename);
        }
        catch (System.Exception e)
        {
            Debug.LogError("데이터 저장 중 오류 발생: " + e.Message);
        }
    }

    public void LoadData()
    {
        string filePath = path + filename;

        try
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                nowPlayer = JsonUtility.FromJson<PlayerData>(data);
                Debug.Log("데이터 로드 완료: " + path + filename);
            }
            else
            {
                nowPlayer = startingPlayer;
                SaveData(); // 기본 데이터 저장
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("데이터 로드 중 오류 발생: " + e.Message);
            nowPlayer = startingPlayer; // 오류 발생 시 기본값 사용
        }
    }

    public void Reset()
    {
        nowPlayer = startingPlayer;
        SaveData(); // 초기화 후 저장
        Debug.Log("데이터 초기화 완료.");
    }
}
