using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;

public class AiLink : LuaLink {

    void awake() {


    }

    public override void init(ILuaState state) {
        scriptName = "AI";
        scriptLocation = "Engine";
        base.init(state);
    }

    protected override void registerFunctions() {
        regFunction("RigidBodyC", "Log",            Log);
        
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    

}
