using Leguar.TotalJSON;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static SerializableListString;

public enum SaveSwitch
{
    json,
    binary
}

public class InventorySaveSystem : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;

    public SaveSwitch saveType = SaveSwitch.json;

    public ItemDatabase ItemDB;

    //SL is our serializable class that contains a representation of the items we want to save - this is a COPY
    private SerializableListString SL = new SerializableListString();


    private void OnEnable()
    {
        //clear the inventory
        playerInventory.CurrentInventory.Clear();
        Debug.Log("Inventory Count = " + playerInventory.CurrentInventory.Count);

        //clear the SL - we don't want anything in there
        SL.serializableList.Clear();
        //Load our save file
        LoadScriptables();
        //re-import our save back into the game world
        ImportSaveData();
    }

    private void OnDisable()
    {
        //clear the SL 
        SL.serializableList.Clear();
        // build our save data from our current game state
        BuildSaveData();
        //save out the save data
        SaveScriptables();
    }

    private void ImportSaveData()
    {
        Debug.Log("Import Save Data " + SL.serializableList.Count);
        //go through the Sl and rebuild the items in the inventory
        for (int i = 0; i < SL.serializableList.Count; i++)
        {

            //we will need the name and the count from the save data
            string name = SL.serializableList[i].name;
            int count = SL.serializableList[i].count;


            // we dont save the actual scriptable objects only a reference (NAME) that we then lookup to insert the correct scriptable object
            InventoryItem obj = ItemDB.GetItem(name);
            if (obj)
            {
                // we have an object to restor - check how many of that item we need and set it 
                obj.NumberHold = count;

                // add the object to the inventory
                playerInventory.CurrentInventory.Add(obj);
                Debug.Log("Added " + obj.ItemName + " count " + count + " to inventory");

            }
            else
            {
                Debug.LogError("ITEM DB Not Found: " + SL.serializableList[i].name);
            }


        }
    }

    private void BuildSaveData()
    {

        //go through the inventory and save out a key value pair of itemName and itemCount
        //then add to the serializablelist
        for (int i = 0; i < playerInventory.CurrentInventory.Count; i++)
        {
            //create a SerialItem and populate it from the inventory
            SerialItem SI = new SerialItem();
            SI.name = playerInventory.CurrentInventory[i].ItemName;
            SI.count = playerInventory.CurrentInventory[i].NumberHold;

            //add to our SL - 
            SL.serializableList.Add(SI);
        }
    }


    public void SaveScriptables()
    {
        //ResetScriptables();
        Debug.Log("IS: Saving to: " + Application.persistentDataPath);


        switch (saveType)
        {
            case SaveSwitch.json:
                Debug.Log("Save is via json");
                JSONSave();
                break;

            case SaveSwitch.binary:
                Debug.Log("Save is via binary");
                BinarySave();

                break;

            default:
                break;
        }



    }

    private void BinarySave()
    {
        BinarySaver.Save(SL.serializableList, "Inventory");
    }

    private void BinaryLoad()
    {
        SL.serializableList = BinarySaver.Load<List<SerialItem>>("Inventory");
    }

    private void JSONSave()
    {
        //filepath
        string filepath = Application.persistentDataPath + "/newsave.json";

        //create a streamwriter
        StreamWriter sw = new StreamWriter(filepath);

        //use the JSON library to serialize our serializableList into a JSON object
        JSON jsonObject = JSON.Serialize(SL);

        //turn that JSON object into a pretty formatted string
        string json = jsonObject.CreatePrettyString();

        //write to our file
        sw.WriteLine(json);

        //close the file
        sw.Close();
    }


    public void LoadScriptables()
    {
        Debug.Log("IS: Loading From: " + Application.persistentDataPath);


        switch (saveType)
        {
            case SaveSwitch.json:
                Debug.Log("Load is via json");
                JSONLoad();
                break;

            case SaveSwitch.binary:
                Debug.Log("Load is via binary");
                BinaryLoad();

                break;


            default:
                break;
        }
    }


    public void JSONLoad()
    {

        //filepath
        string filepath = Application.persistentDataPath + "/newsave.json";

        if (File.Exists(filepath))
        {
            //read in the file to a string
            string json = File.ReadAllText(filepath);
            //use the JSON library to parse the string
            JSON jsonObject = JSON.ParseString(json);
            //deserialize the JSON object back into our Serializable class
            SL = jsonObject.Deserialize<SerializableListString>();
        }

    }

}
