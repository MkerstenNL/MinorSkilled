using UnityEngine;
using System.Collections;
using UniLua;
using System;
using System.Collections.Generic;

public class WorldLua : LuaLink {

	// Use this for initialization
	void Start () {
        init();
        Debug.Assert(scriptName != "");
        
        //CallLuaFunction("Start");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void registerFunctions() {
        regFunction(scriptName + "C", "Log", Log);
        foreach ( KeyValuePair<string,List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    ////////////////////////////////////////
    /// LuaFunctions
    ////////////////////////////////////////

    public override int Log(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("incorrect number of arguments");
            return 1;
        }
        string message = state.ToObject(1).ToString();
        Debug.Log(message.ToString());
        _lua.SetTop(0);

        return 0;
    }
}
