using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDLuaLink : LuaLink {

    [SerializeField]InputField hintField;
    [SerializeField]MessageSystem messageField;

    void Start() {
        hintField = GameObject.FindGameObjectWithTag("hintfield").GetComponent<InputField>();
        messageField = GameObject.FindGameObjectWithTag("Message").GetComponent<MessageSystem>();
    }

    public override void init(ILuaState state) {
        scriptLocation = "Engine";
        scriptName = "HUD";
        base.init(state);
    }

    void OnTriggerEnter(Collider trigger) {
        _lua.GetGlobal("OnHit");
        if ( _lua.IsFunction(-1) ) {
            _lua.PushString(trigger.gameObject.name);
            _lua.PCall(1, 0, 0);
        }
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
        messageField.SetMessage(message);
        return 0;
    }

    public int SetHint(ILuaState state) {
        string message = state.ToString(-1);
        hintField.GetComponentInChildren<Text>().text = message;
        return 0;
    }
}
