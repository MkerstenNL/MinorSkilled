using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniLua;
using UnityEngine.UI;

public class GameObjectLuaLink : LuaLink {
    ScriptFactory _scriptFactory;
    List<Component> RuntimeAddedComponenets = new List<Component>();
    
	// Use this for initialization
	void Start () {
        //init();
        Debug.Assert(scriptName != "");
        _scriptFactory = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptFactory>();
        //CallLuaFunction("GameObject", "Start");
    }
	
	// Update is called once per frame
	void Update () {
        if ( _lua == null ) return;
        //CallLuaFunction("GameObject","Update");
	}
    public override void init() {
        if ( RuntimeAddedComponenets.Count > 0 ) {
            foreach ( Component c in RuntimeAddedComponenets ) {
                Component.Destroy(c);
            }
        }
        base.init();
        CallLuaFunction("GameObject", "Start");
    }

    public int GetGlobalFromOtherState(ILuaState otherstate) {
        otherstate.SetTop(0);//safety measure
        _lua.GetGlobal("GameObject");
        _lua.XMove(otherstate, 1);
        return 0;
    }

    ////////////////////////////////////////
    /// LuaFunctions
    ////////////////////////////////////////

    protected override void registerFunctions() {
        regFunction(scriptName + "C", "Log", Log);
        regFunction(scriptName + "C", "NewComponent", NewComponent);
        regFunction(scriptName + "C", "MessageBoard", MessageBoard);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }

    }

    public int NewComponent(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            //_lua.PushString("this function needs 1 parameter.");
            return 0;
        }
        string s = state.ToString(-1);
        Type t = _scriptFactory.GetScriptType(s);
        if ( t == null ) {
            _lua.SetTop(0);
           // _lua.PushString("Error 404: ScriptNameNotFound");
            return 0;
        } else {
            LuaLink l = gameObject.AddComponent(t) as LuaLink;
            RuntimeAddedComponenets.Add(l);
            l.init(_lua);
            //_lua.PushGlobalTable();
            //_lua.SetGlobal(s);
            //Debug.Log(_lua.GetTop());
            //_lua.SetTop(1);
            //_lua.PushString("Operation Successful");
            return 0;
        }
    }

    public int MessageBoard(ILuaState state)
    {
        if (lua.GetTop() != 1)
        {
            _lua.SetTop(0);
            return 0;
        }
        string textLua = _lua.ToString(-1);
        GameObject.Find("Message").GetComponent<MeshRenderer>().material = Resources.Load("MessageBoardMat") as Material;
        GameObject.Find("MessageDirty").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("TriggerMessageComplete").AddComponent<BoxCollider>().isTrigger = true;
        //Text[] texts = GameObject.Find("MessageCanvas").GetComponentsInChildren<Text>();
        // object messageboard = Resources.Load("MessageBoard");
        //foreach (Text text in texts)
        //{
        //    text.text = textLua;
        //}
        return 0;
    }
}
