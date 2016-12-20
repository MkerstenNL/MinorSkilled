using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDLuaLink : LuaLink {

    [SerializeField]InputField HintField;
    [SerializeField]InputField MessageField;

    public override void init(ILuaState state) {
        scriptLocation = "Engine";
        scriptName = "HUD";
        base.init(state);
    }


    protected override void registerFunctions() {
        regFunction(scriptName + "C", "Log", Log);
        regFunction(scriptName + "C", "SetMessage", SetMessage);
        regFunction(scriptName + "C", "SetHint", SetHint);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public int SetMessage(ILuaState state) {
        string message = state.ToString(-1);
        //set it in the hud
        return 0;
    }

    public int SetHint(ILuaState state) {
        string message = state.ToString(-1);
        return 0;
    }
}
