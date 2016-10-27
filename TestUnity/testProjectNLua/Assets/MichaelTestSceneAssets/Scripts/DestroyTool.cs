using UnityEngine;
using System.Collections;
using UnityEditor;

public class DestroyTool : ToolBase {

    public override void Activate(GameObject obj) {
        RaycastHit hit;
        Debug.Log("test");
        
        if ( Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 100) ) {
            if(hit.collider.gameObject.name=="Terrain")return;
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

    public override string ToString() {
        return "DestructionTool";
    }

}
