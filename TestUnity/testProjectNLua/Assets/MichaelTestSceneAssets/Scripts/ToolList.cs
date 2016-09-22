using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
public class ToolList : ScriptableObject {

   [SerializeField] private List<ToolBase> tools = new List<ToolBase>();
    int id = 0;


    [MenuItem("Assets/AssetCreator/ToolList")]
    public static void CreateNewToolListAsset() {
        ToolList asset = ScriptableObject.CreateInstance<ToolList>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/ToolList.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    public ToolBase getNextTool() {
        Debug.Log(tools.Count+"      "+ id);
        tools[id].DeEquip();
        id = ( id + 1 ) % (tools.Count);
        tools[id].Equip();
        return tools[id];
    }



}
