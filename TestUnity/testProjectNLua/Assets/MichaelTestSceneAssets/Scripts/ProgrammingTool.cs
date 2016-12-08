using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class ProgrammingTool : ToolBase {

    BehaviourManager _manager;
    [SerializeField]LuaCanvasManager _luaManager;
    GameObject World;

    public override void Activate(GameObject obj)
    {
        //if (obj.tag != "Programmable")return;
        if (_manager==null)_manager = FindObjectOfType<BehaviourManager>();
        RaycastHit hit;
        int layermask = 1<<8;
        layermask = ~layermask;
        if(Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 10,layermask)){
            if (hit.collider.gameObject.tag == "Programmable")
            {
                _manager.AddBehaviour(hit.collider.gameObject);
            }
        }
    }

    public override void DeActivate() {
        BehaviourManager.UsingHud = true;
        if(World==null)World = GameObject.FindGameObjectWithTag("World");
        //if(_luaManager==null)_luaManager = GameObject.FindGameObjectWithTag("LuaManager").GetComponent<LuaCanvasManager>();
        _luaManager.Enable("World", World);
    }

    public override void DeEquip() {
       // throw new NotImplementedException();
    }

    public override void Equip() {
       // throw new NotImplementedException();
    }

    public override string ToString() {
        return "ProgrammingTool";
    }

}
