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
        regFunction("TransformC", "GetPosition", GetPosition);
        regFunction("TransformC", "GetDirection", GetDirection);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public int GetPosition(ILuaState state) {
        if ( state.GetTop() != 0 ) {
            _lua.SetTop(0);
            state.PushString("Invalid amount of parameters. function requires 0");
            return 1;
        }
        Debug.Log("GotPosition");
        _lua.PushNumber(this.transform.position.x);
        _lua.PushNumber(this.transform.position.y);
        _lua.PushNumber(this.transform.position.z);
        return 3;
    }

    public int GetDirection(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("Incorrect number of arguments. function requires 0");
            return 1;
        }
        Debug.Log("GOtDirection");
        Vector3 dir = Vector3.zero;
        switch ( state.ToString(1) ) {
            case "Up":
                dir = Vector3.up;
            break;

            case "Down":
            dir = Vector3.down;
            break;

            case "Left":
            dir = Vector3.left;
            break;

            case "Right":
            dir = Vector3.right;
            break;

            case "Forward":
            dir = Vector3.forward;
            break;

            case "Back":
            dir = Vector3.back;
            break;

            default:
            state.PushString("invalid parameter");
            return 1;
        }
        _lua.PushNumber(dir.x);
        _lua.PushNumber(dir.y);
        _lua.PushNumber(dir.z);
        return 3;
    }

    public int SetPosition(ILuaState state) {
        if ( state.GetTop() != 3 ) {
            _lua.SetTop(0);
            _lua.PushString("Incorrect number of arguments");
            return 1;
        }
        Debug.Log("Setting position");
        Vector3 newPos = Vector3.zero;
        newPos.z = (float)_lua.ToNumber(3);
        newPos.y = (float) _lua.ToNumber(2);
        newPos.x = (float) _lua.ToNumber(1);
        this.transform.position = newPos;
        _lua.SetTop(0);
        _lua.PushString("Position Set");
        return 1;
    }
}
