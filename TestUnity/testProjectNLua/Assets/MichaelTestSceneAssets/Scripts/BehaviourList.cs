using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class BehaviourList : ScriptableObject {

    [MenuItem("Assets/AssetCreator/Tools/BehaviourList")]
    public static void CreateNewToolListAsset() {
        BehaviourList asset = ScriptableObject.CreateInstance<BehaviourList>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/BehaviourList.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [SerializeField]List<CustomBehaviour> _behaviours = new List<CustomBehaviour>();
    public List<CustomBehaviour> Behaviours {
        get { return _behaviours;}
    }

}
