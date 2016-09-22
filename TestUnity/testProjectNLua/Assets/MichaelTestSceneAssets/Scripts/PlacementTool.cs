using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

[System.Serializable]
public class PlacementTool : ToolBase {

    [MenuItem("Assets/AssetCreator/Tools/Placement")]
    public static void CreateNewToolListAsset() {
        PlacementTool asset = ScriptableObject.CreateInstance<PlacementTool>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/PlacementTool.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }


    public override void Activate(GameObject obj) {
        RaycastHit hit;
        Debug.Log("test");
        if ( Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 100) ) {
            Debug.Log("hit");
            Debug.Log(hit.collider.name);
            if(hit.collider.gameObject.name=="Terrain")return;
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3( Mathf.Round(hit.point.x - obj.transform.forward.x),
                                                 Mathf.Round(hit.point.y - obj.transform.forward.y) +0.5f,
                                                 Mathf.Round(hit.point.z - obj.transform.forward.z));
            

        }



    }

    public override void DeActivate() {
        throw new NotImplementedException();
    }

    public override void DeEquip() {
        
    }

    public override void Equip() {
        
    }
}
