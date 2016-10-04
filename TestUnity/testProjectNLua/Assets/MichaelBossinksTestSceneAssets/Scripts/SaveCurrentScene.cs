using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using SimpleJson;
using System.IO;
using System;

public struct SaveClass
{
    public string gameObjectName;
    public string source;
    public Vector3 originalPosition;
    public Quaternion originalRotation;

}

public static class SaveCurrentScene {


    static string jsonString;
    public static void SaveJsonScene(List<GameObject> pGameObjectsInScene, string pSaveGameName)
    {
        jsonString = "";
        foreach (GameObject gameObjectInScene in pGameObjectsInScene)
        {
            Debug.Log(gameObjectInScene.name);
            string luaSource;
            if (gameObjectInScene.GetComponent<LuaContainerOfObject>())
            {
                luaSource = gameObjectInScene.GetComponent<LuaContainerOfObject>().GetSource();
            }
            else
            {
                luaSource = "";
            }
            SaveClass saveClass = new SaveClass();
            saveClass.gameObjectName = gameObjectInScene.name;
            saveClass.source = luaSource;
            saveClass.originalPosition = gameObjectInScene.GetComponent<IsClickedOnMouse>().OrignalPosition;
            saveClass.originalRotation = gameObjectInScene.GetComponent<IsClickedOnMouse>().OrignalRotation;
            jsonString += JsonUtility.ToJson(saveClass);
            jsonString += "\n";
            if (!File.Exists(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/"+pSaveGameName+".json"))
            {
                File.Create(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/" + pSaveGameName + ".json").Dispose();
            }
        }

        File.WriteAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/" + pSaveGameName + ".json", jsonString);
        Debug.Log(jsonString);
    }

   public static void LoadJsonScene(string pSaveName)
    {
       string loadJson = "";
        //pSaveName = "SaveGame1";
        if (!File.Exists(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/"+pSaveName+".json"))
        {
            //SaveFile not found or currupt
        }
        else
        {
            loadJson = File.ReadAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/"+pSaveName+".json");
        }
       foreach (string line in File.ReadAllLines(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/SaveGames/"+pSaveName+".json"))
	    {
            SaveClass jsonLoadedClass = (SaveClass)JsonUtility.FromJson(line, typeof(SaveClass));
            GameObject world = GameObject.FindObjectOfType<CreateObjectFromLua>().gameObject;
            //world.GetComponent<LuaContainerOfObject>().CreateObject(jsonLoadedClass.gameObjectName,jsonLoadedClass.source);
            if (jsonLoadedClass.gameObjectName == "World")
            {
                world.GetComponent<LuaContainerOfObject>().SaveLua(jsonLoadedClass.source, jsonLoadedClass.gameObjectName, true);
            }
            else
            {
                world.GetComponent<LuaContainerOfObject>().SaveLua(jsonLoadedClass.source, jsonLoadedClass.gameObjectName, false);
            }


	    }
        //File.ReadAllLines()
        
        //JsonUtility.FromJson(loadJson, typeof(SaveClass));

    }
}
