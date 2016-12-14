using UnityEngine;

public class ProgrammingTool :ScriptableObject{
    private string tagToCheck = "Programmable";

    public void Activate(GameObject obj) {
        RaycastHit info;
        if(Physics.Raycast(obj.transform.position,obj.transform.forward,out info, 5)){
            if ( info.collider.tag != tagToCheck ) return;
            //ToDo implement LuaScripting

        }
    }
}