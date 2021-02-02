using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Instantiate gamemanager to save.
    /// </summary>
    public static GameManager gameManager;

    public List<ScriptableObject> objects = new List<ScriptableObject>();

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }


    private void OnEnable()
    {
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
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
            Debug.Log("Game Saved");
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),objects[i]);
                file.Close();
                Debug.Log("Game Loaded");
            }
        }
    }
}
