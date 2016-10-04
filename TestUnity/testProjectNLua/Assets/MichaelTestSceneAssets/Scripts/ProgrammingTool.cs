using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class ProgrammingTool : ToolBase {

    BehaviourManager _manager;

    [MenuItem("Assets/AssetCreator/Tools/Programming")]
    public static void CreateNewToolListAsset() {
        ProgrammingTool asset = ScriptableObject.CreateInstance<ProgrammingTool>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/ProgrammingTool.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    public override void Activate(GameObject obj) {
        if (obj.tag == "Terrain")return;
        if (_manager==null)_manager = FindObjectOfType<BehaviourManager>();
        RaycastHit hit;
        if(Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 10)){
            _manager.AddBehaviour(hit.collider.gameObject);
        }
    }

    public override void DeActivate() {
      //  throw new NotImplementedException();
    }

    public override void DeEquip() {
       // throw new NotImplementedException();
    }

    public override void Equip() {
       // throw new NotImplementedException();
    }

}
