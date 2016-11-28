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
        CallLuaFunction("Start");
    }

    protected override void registerFunctions() {
        regFunction("TransformC", "Log", Log);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }
}
