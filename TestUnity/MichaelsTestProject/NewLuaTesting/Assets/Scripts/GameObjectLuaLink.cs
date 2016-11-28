using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniLua;

public class GameObjectLuaLink : LuaLink {
    ScriptFactory _scriptFactory;
    
	// Use this for initialization
	void Start () {
        init();
        Debug.Assert(scriptName != "");
        _scriptFactory = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptFactory>();
        CallLuaFunction("Start");
    }
	
	// Update is called once per frame
	void Update () {
        //CallLuaFunction("Update");
	}
    ////////////////////////////////////////
    /// LuaFunctions
    ////////////////////////////////////////


    protected override void registerFunctions() {
        regFunction(scriptName + "C", "Log", Log);
        regFunction(scriptName + "C", "NewScript", newComponent);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public int newComponent(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("this function needs 1 parameter.");
            return 1;
        }
        Type t = _scriptFactory.GetScriptType(state.ToString(1));
        if ( t == null ) {
            _lua.SetTop(0);
            _lua.PushString("Error 404: ScriptNameNotFound");
            return 1;
        } else {
            LuaLink l = gameObject.AddComponent(t) as LuaLink;
            l.init(_lua);
            _lua.SetTop(0);
            _lua.PushString("Operation Successful");
        }

        
        return 1;
    }


}
