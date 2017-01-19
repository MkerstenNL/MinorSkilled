using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniLua;
using System.IO;
using System;

public class WorldLuaLink : LuaLink {
    GameObjectLuaLink[] programmableObjects; 
    // Use this for initialization
	void Awake () {
        scriptLocation = "Engine";
        scriptName = "WorldEngine";
        programmableObjects = FindObjectsOfType<GameObjectLuaLink>();
        init();
    }

    public override void init(ILuaState state) {
        base.init(state);
        CallLuaFunction("WorldEngine","Start");
    }

    protected override void registerFunctions() {
        regFunction("WorldC", "Log", Log);
        regFunction("WorldC", "CreateObject", CreateObject);

        _lua.L_OpenLibs();
        foreach ( KeyValuePair<string, List<UniLua.NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public ILuaState GetWorld(ILuaState state) {
        _lua.GetGlobal("WorldEngine");
        _lua.XMove(state, 1);
        return state;
    }

    /////////////////
    ///Lua Functions
    /////////////////

    public int FindProgrammableObject(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            state.SetTop(0);
        }
        string objectname = state.ToString();
        foreach ( GameObjectLuaLink g in programmableObjects ) {
            if ( g.name == objectname ) {
                g.GetGlobalFromOtherState(state);
                return 1;
            }
        }
        //state.PushString("OperationFailed");
        return 0;
    }

    public int CreateObject(ILuaState state)
    {
        if (state.GetTop() != 4)
        {
            state.SetTop(0);
        }
        string luaPrefabName = _lua.ToString(-4);
        GameObject prefab = (GameObject)Resources.Load(_lua.ToString(-4));
        GameObject createdObject = (GameObject)UnityEngine.Object.Instantiate(prefab,new Vector3((float)_lua.ToNumber(-3), (float)_lua.ToNumber(-2), (float)_lua.ToNumber(-1)),prefab.gameObject.transform.rotation);
        createdObject.transform.name = createdObject.transform.name.Replace("(Clone)", "");
        _lua.SetTop(0);
        return 0;
    }

    public void FindObject() {

    }
}
