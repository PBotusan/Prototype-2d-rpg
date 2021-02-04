using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class InventorySaveSystem : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;



    private void OnEnable()
    {
        playerInventory.CurrentInventory.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    /// <summary>
    /// Save scriptables and create file.
    /// </summary>
    public void SaveScriptables()
    {
        ResetScriptables();
        for (int i = 0; i < playerInventory.CurrentInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(playerInventory.CurrentInventory[i]);
            binary.Serialize(file, json);
            file.Close();
            Debug.Log("Game Saved");
        }
    }

    public void LoadScriptables()
    {
        int i = 0;
        while(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            var temp = ScriptableObject.CreateInstance<InventoryItem>();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
            file.Close();
            Debug.Log("Game Loaded");
            playerInventory.CurrentInventory.Add(temp);
            i++;
        }
    }

    public void ResetScriptables()
    {
        int i = 0;
        while(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            i++;
            Debug.Log("ResetScriptables");
        }
    }

    /*
    public void ResetHeartValues()
    {
        playerHealthManager.heartContainers.RuntimeValue = 3;
        playerHealthManager.playerCurrentHealth.RuntimeValue = 6;
        Debug.Log("Reset Hearts");
    }

    public void ResetInventory()
    {
        inventory.Coins = 0;
        inventory.Arrows = 0;
        inventory.Bombs = 0;
        inventory.NumberOfKeys = 0;

        Debug.Log("Reset Inventory");
    }*/
}
