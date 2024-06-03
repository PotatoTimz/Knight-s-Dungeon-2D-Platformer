using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    private Player playerStats;

    private void Start()
    {
        playerStats = gameObject.GetComponent<Player>();
    }
    public void SaveToJson()
    {
        SavedData save = new SavedData(playerStats.numOfClears, playerStats.numOfDeaths, coinManager.coinCount);

        string inventoryData = JsonUtility.ToJson(save);
        string filePath = Application.persistentDataPath + "/SaveData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
    }

    public SavedData LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";
        bool foundFile = System.IO.File.Exists(filePath);

        SavedData save;

        if (foundFile)
        {
            string saveData = System.IO.File.ReadAllText(filePath);
            save = JsonUtility.FromJson<SavedData>(saveData);
        }
        else
        {
            save = null;
        }

        return save;
    }
}




