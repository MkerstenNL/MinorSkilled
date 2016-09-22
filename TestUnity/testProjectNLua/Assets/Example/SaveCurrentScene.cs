using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using SimpleJson;

public static class SaveCurrentScene {
    

    public static void SaveJsonScene(List<GameObject> pGameObjectsInScene)
    {
        foreach (GameObject gameObjectInScene in pGameObjectsInScene)
        {
            JsonUtility.ToJson(gameObjectInScene);
        }
    }
}
