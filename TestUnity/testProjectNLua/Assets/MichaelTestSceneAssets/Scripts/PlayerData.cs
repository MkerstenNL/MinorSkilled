using UnityEngine;
using UnityEditor;
using System.Collections;



public class PlayerDataCreator : ScriptableObject {

    [MenuItem("Assets/AssetCreator/PlayerData")]
    public static void CreatePlayerData() {
        PlayerData asset = ScriptableObject.CreateInstance<PlayerData>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/PlayerData.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;


    }

}

public class PlayerData : ScriptableObject {
    public  float MovementSpeed = 5;
    public  float RotateSpeed = 3;

}
