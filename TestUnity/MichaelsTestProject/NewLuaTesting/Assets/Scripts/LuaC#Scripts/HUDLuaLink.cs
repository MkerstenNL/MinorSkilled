using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDLuaLink : LuaLink {

    private int _score = 0;
    private List<string> _inventory = new List<string>();
    [SerializeField]InputField hintField;
    [SerializeField]MessageSystem messageField;

    void Awake() {
        scriptName = "HUD";
        scriptLocation = "Engine";
        //hintField = GameObject.FindGameObjectWithTag("HintField").GetComponent<InputField>();
        //messageField = GameObject.FindGameObjectWithTag("Message").GetComponent<MessageSystem>();
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
        regFunction("HUDC", "Log", Log);
        regFunction("HUDC", "SetMessage", SetMessage);
        regFunction("HUDC", "SetHint", SetHint);
        regFunction("HUDC", "Score", Score);
        regFunction("HUDC", "Inventory", Inventory);
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
    public int Score(ILuaState state)
    {
        _score = (int)_lua.ToNumber(-1);
        _lua.SetTop(0);
        return 0;
    }
    public int Inventory(ILuaState state)
    {
        _inventory.Add(_lua.ToString(-1));
        return 0;
    }
}
