using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;

public class TransformLuaLink : LuaLink {
    
	// Use this for initialization
	void Start () {
        scriptName = "Transform";
        scriptLocation = "Engine";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void init(ILuaState state) {
        scriptName = "Transform";
        scriptLocation = "Engine";
        base.init(state);
        
    }

    protected override void registerFunctions() {
        regFunction("TransformC", "Log", Log);
        regFunction("TransformC", "SetPosition", SetPosition);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public int SetPosition(ILuaState state) {
        if ( state.GetTop() != 3 ) {
            _lua.SetTop(0);
            _lua.PushString("Incorrect number of arguments");
            return 1;
        }
        Vector3 newPos = Vector3.zero;
        newPos.z = (float)_lua.ToNumber(3);
        newPos.y = (float) _lua.ToNumber(2);
        newPos.x = (float) _lua.ToNumber(1);
        this.transform.position = newPos;
        _lua.PushString("PositionSet");
        return 1;
    }
}
