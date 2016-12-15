using UnityEngine;


public class ProgrammingTool : MonoBehaviour{
    private string tagToCheck = "Programmable";
    [SerializeField]private CanvasManager cm = null;

    public void Activate(GameObject obj) {
        RaycastHit info;
        if(Physics.Raycast(obj.transform.position,obj.transform.forward,out info, 5)){
            if ( info.collider.tag != tagToCheck ) return;
            cm.LoadScript(info.collider.gameObject.GetComponent<TopLevelLua>());
        }
    }
}