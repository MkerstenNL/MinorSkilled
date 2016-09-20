using UnityEngine;
using System.Collections;
using UnityEditor;

public class DestroyTool : ToolBase {
    [MenuItem("Assets/AssetCreator/Tools/Destroy")]
    public static void CreateNewToolListAsset() {
        DestroyTool asset = ScriptableObject.CreateInstance<DestroyTool>();
        AssetDatabase.CreateAsset(asset, "Assets/MichaelTestSceneAssets/DestroyTool.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }


    public override void Activate(GameObject obj) {
        RaycastHit hit;
        Debug.Log("test");
        if ( Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 100) ) {
            Debug.Log("hit");
            GameObject.Destroy(hit.collider.gameObject);

        }



    }

    public override void DeActivate() {
       
    }

    public override void DeEquip() {

    }

    public override void Equip() {

    }

}
