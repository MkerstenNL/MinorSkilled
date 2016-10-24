using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class ProgrammingTool : ToolBase {

    BehaviourManager _manager;
    [SerializeField]LuaCanvasManager _luaManager;
    GameObject World;

    public override void Activate(GameObject obj) {
        if (obj.tag == "Terrain")return;
        if (_manager==null)_manager = FindObjectOfType<BehaviourManager>();
        RaycastHit hit;
        if(Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 10)){
            _manager.AddBehaviour(hit.collider.gameObject);
        }
    }

    public override void DeActivate() {
        if(World==null)World = GameObject.FindGameObjectWithTag("World");
        if(_luaManager==null)_luaManager = GameObject.FindGameObjectWithTag("LuaManager").GetComponent<LuaCanvasManager>();
        _luaManager.Enable("World", World);
    }

    public override void DeEquip() {
       // throw new NotImplementedException();
    }

    public override void Equip() {
       // throw new NotImplementedException();
    }

}
