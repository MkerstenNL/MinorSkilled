using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniLua;
using System.IO;
using System;

public class WorldLuaLink : MonoBehaviour {
    private UniLua.ILuaState _luaState = null;
    private string scriptName = "Engine/World";
    // Use this for initialization
    private Dictionary<string,List<NameFuncPair>> _luaLibs = new Dictionary<string, List<NameFuncPair>>();
	void Start () {
        _luaState = LuaAPI.NewState();
        loadFile(scriptName);
        openLib(_luaState);
        callLuaFunction("Start");
	}

    private void add(string lib, string functionName, CSharpFunctionDelegate function) {
        if ( !_luaLibs.ContainsKey(lib) ) {
            _luaLibs.Add(lib, new List<NameFuncPair>());
        }
        _luaLibs[lib].Add(new NameFuncPair(functionName, function));
    }

    private int openLib(ILuaState pLua) {
        add("WorldC", "Log", Log);
        add("WorldC", "GetPosition", GetPosition);
        _luaState.L_OpenLibs();
        foreach ( KeyValuePair<string, List<UniLua.NameFuncPair>> lib in _luaLibs ) {
            _luaState.L_NewLib(lib.Value.ToArray());
            _luaState.SetGlobal(lib.Key);
        }


        return 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void callLuaFunction(string functionName) {
        _luaState.GetGlobal("Start");
        if ( _luaState.IsFunction(-1) ) {
            _luaState.PCall(0, 0, 0);
        }
    }

    private void loadFile(string pFile) {
        try {
            ThreadStatus status = _luaState.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/" + pFile + ".lua");
            if ( status == ThreadStatus.LUA_OK ) {
                Debug.Log("Loading of script " + pFile + " was succesful");
            } else {
                Debug.Log("Loading of script " + pFile + " was a failure. did you use the correct name?");
            }
        } catch (Exception error){
            Debug.Log("Loading " + pFile + " failed. check the name of the object that you are trying to instantiate."+'\n'+"Error message: "+error.Message);
        }

    }

    /////////////////
    ///Lua Functions
    /////////////////

    public int Log(ILuaState lua) {
        string s = _luaState.ToString(1);
        Debug.Log(s);
        return 0;
    }

    public int GetPosition(ILuaState lua) {
        _luaState.PushNumber(transform.position.x);
        _luaState.PushNumber(transform.position.y);
        _luaState.PushNumber(transform.position.z);
        return 3;
    }
}
